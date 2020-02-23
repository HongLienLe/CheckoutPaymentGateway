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
        private Merchant GetMerchant()
        {
            return new Merchant("Merchant Name");
        }
    }
}