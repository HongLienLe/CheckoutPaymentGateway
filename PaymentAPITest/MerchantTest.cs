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
        //Testing HTTP Status code for each controller

        [Test]
        public void getMerchant_returns_400_response_when_id_returns_null()
        {
            var mockRepo = new Mock<IMerchantRepository>();
            mockRepo.Setup(x => x.GetMerchant(1)).Returns((Merchant)null);

            var merchantController = new MerchantController(mockRepo.Object);
            var result = merchantController.GetMerchant(1) as ObjectResult;

            Assert.AreEqual(404, result.StatusCode);
        }

        [Test]
        public void getMerchant_returns_200_merchant_when_id_exist()
        {
 
            var mockRepo = new Mock<IMerchantRepository>();
            mockRepo.Setup(x => x.GetMerchant(1)).Returns(GetMerchant());

            var merchantController = new MerchantController(mockRepo.Object);
            var result = merchantController.GetMerchant(1) as ObjectResult;

            Assert.AreEqual(200, result.StatusCode);
        }



        private List<Merchant> GetMerchants()
        {
            List<Merchant> merchants = new List<Merchant>()
            {
                new Merchant()
                {
                    MerchantId = 1,
                    Name = "Merchant 1",
                    MinAmount = 0,
                    MaxAmount = 1000,
                },
                new Merchant()
                {
                    MerchantId = 2,
                    Name = "Merchant 2",
                    MinAmount = 0,
                    MaxAmount = 2000,
                },
                new Merchant()
                {
                    MerchantId = 3,
                    Name = "Merchant 3",
                    MinAmount = 0,
                    MaxAmount = 3000,
                }
            };

            return merchants;
        }

        private Merchant GetMerchant()
        {
            return new Merchant()
            {
                Name = "Merchant Name",
                MinAmount = 0,
                MaxAmount = 100
            };
        }
    }
}