using NUnit.Framework;
using Moq;
using PaymentAPI.Process;
using PaymentAPI.Models;
using System.Collections.Generic;
using PaymentAPI.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace PaymentAPITest
{
    public class MerchantTest
    {

        [Test]
        public void returns_not_found_response_when_id_returns_null()
        {
            var mockRepo = new Mock<IMerchantRepository>();
            mockRepo.Setup(x => x.GetMerchant(1)).Returns((Merchant)null);

            var merchantController = new MerchantController(mockRepo.Object);

            var result = merchantController.GetMerchant(1) as ObjectResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        private List<Merchant> GetMerchants()
        {
            List<Merchant> merchants = new List<Merchant>()
            {
                new Merchant()
                {
                    MerchantId = 1,
                    Name = "Merchant 1",
                    LowerBound = 0,
                    UpperBound = 1000,
                },
                new Merchant()
                {
                    MerchantId = 2,
                    Name = "Merchant 2",
                    LowerBound = 0,
                    UpperBound = 2000,
                },
                new Merchant()
                {
                    MerchantId = 3,
                    Name = "Merchant 3",
                    LowerBound = 0,
                    UpperBound = 3000,
                }
            };

            return merchants;
        }
    }
}