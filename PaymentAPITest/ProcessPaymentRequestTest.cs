using NUnit.Framework;
using Moq;
using PaymentAPI.Process;
using PaymentAPI.Models;
using System.Collections.Generic;
using PaymentAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using PaymentAPI.Data;
using System;

namespace PaymentAPITest
{
    public class ProcessPaymentRequestTest
    {

        private ConnectionFactory _connectionFactory { get; set; }
        private CPGContext _context {get;set;}

        [Test]
        public void return_404_bad_request_when_amount_is_out_of_range()
        {
            Card card = new Card("1234567890", 1, 2020, "123", "Test");
            PaymentRequest paymentRequest = new PaymentRequest(100000, "ABC", 1, card);
            var controller = GetProcessPaymentRequestController(false, paymentRequest);

            var result = controller.PostRequest(paymentRequest) as ObjectResult;

            EndConnection();

            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual($"Amount is not within range. Min Amount = 0 - 1000", result.Value);
        }

        [Test]
        public void return_404_bad_request_when_merchant_does_not_exist()
        {
            Card card = new Card("1234567890123456", 1, 2020, "123", "Test");
            var paymentRequest = new  PaymentRequest(1, "ABC", 100, card);

            var controller = GetProcessPaymentRequestController(false, paymentRequest);

            var result = controller.PostRequest(paymentRequest) as ObjectResult;

            EndConnection();

            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual("Merchant does not exist", result.Value);
        }

        [Test]
        public void return_200_when_payment_has_been_process()
        {
            Card card = new Card("1234567890", 1, 2020, "123", "Test");
            PaymentRequest paymentRequest = new PaymentRequest(100, "ABC", 1, card);
            var controller = GetProcessPaymentRequestController(true, paymentRequest);

            var result = controller.PostRequest(paymentRequest) as ObjectResult;

            var merchantPaymentRequest = _context.Merchants.First(x => x.MerchantId == 1).PaymentRequests.ToList();
            var paymentRequestAmount = _context.PaymentRequests.First(x => x.amount == 100).amount;

            EndConnection();

            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(result.Value, $"Payment has been process and stored. PaymentId : 1 Status : Success ");
            Assert.IsTrue(merchantPaymentRequest.Contains(paymentRequest));
            Assert.AreEqual(100, paymentRequestAmount);
        }

        [Test]
        public void return_200_payment_response_valid_via_payment_history()
        {
            var controller = GetPaymentHistoryController();

            var result = controller.GetPaymentsById(1, 1) as ObjectResult;

            EndConnection();

            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);

        }

        [Test]
        public void return_masked_card_number_and_statuc_payment_response()
        {
            _connectionFactory = new ConnectionFactory();
            _context = _connectionFactory.CreateContextForSQLite();

            var paymentHistory = new PaymentHistory(_context);
            SeedPaymentHistoryData();

            var response = paymentHistory.GetPaymentRequest(1, 1);

            EndConnection();

            Assert.IsTrue("************ryT1" == response.card_number);
            Assert.IsTrue(response.Status == "Success");
        }

        [Test]
        public void return_404_merchant_doesnt_exist_via_payment_history()
        {
            var controller = GetPaymentHistoryController();

            var result = controller.GetPaymentsById(100, 100) as ObjectResult;

            EndConnection();

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual("Either or both merchant and payment Id does not exist", result.Value.ToString());

        }

        [Test]
        public void return_400_paymentId_invalid_merchant_valid_via_payment_history()
        {
            var controller = GetPaymentHistoryController();

            var result = controller.GetPaymentsById(1, 100) as ObjectResult;

            EndConnection();

            Assert.IsNotNull(result);
            Assert.AreEqual(404, result.StatusCode);
            Assert.AreEqual("Either or both merchant and payment Id does not exist", result.Value.ToString());
        }



        private ProcessPaymentRequestApiController GetProcessPaymentRequestController(bool bankReponse, PaymentRequest payment)
        {
            _connectionFactory = new ConnectionFactory();
            _context = _connectionFactory.CreateContextForSQLite();

            var bankMoq = new Mock<IBankService>();
            var id = Guid.NewGuid();
            bankMoq.Setup(x => x.GetBankPaymentResponse(payment)).Returns(new BankPaymentResponse(id, bankReponse) { PaymentRequest = payment });

            var processPaymentRequest = new ProcessPaymentRequest(_context, bankMoq.Object);

            return new ProcessPaymentRequestApiController(processPaymentRequest);
        }

        private PaymentHistoryController GetPaymentHistoryController()
        {
            _connectionFactory = new ConnectionFactory();
            _context = _connectionFactory.CreateContextForSQLite();

            var paymentHistory = new PaymentHistory(_context);
            SeedPaymentHistoryData();

            return new PaymentHistoryController(paymentHistory);

        }

        private void EndConnection()
        {
            _context.Database.EnsureDeleted();
            _connectionFactory.connection.Close();

        }

        private void SeedPaymentHistoryData()
        {
            Card card1 = new Card("PaymenthistoryT1", 1, 2021, "CVV", "Test1");
            Card card2 = new Card("PaymenthistoryT2", 2, 2022, "CVV", "Test2");
            Card card3 = new Card("PaymenthistoryT3", 3, 2023, "CVV", "Test3");
            Card card4 = new Card("PaymenthistoryT4", 4, 2024, "CVV", "Test4");

            List<PaymentRequest> paymentRequests = new List<PaymentRequest>() {

                new PaymentRequest(100, "CD1", 1, card1){Status = new BankPaymentResponse(Guid.NewGuid(),true) },
                new PaymentRequest(250, "CD2", 2, card2){Status = new BankPaymentResponse(Guid.NewGuid(),false) },
                new PaymentRequest(3050, "CD3", 3, card3){Status = new BankPaymentResponse(Guid.NewGuid(),true) },
                new PaymentRequest(4000, "CD4", 3, card4){Status = new BankPaymentResponse(Guid.NewGuid(),true) }
            };

            _context.PaymentRequests.AddRange(paymentRequests);
            _context.SaveChanges();
            
        }

    }
}