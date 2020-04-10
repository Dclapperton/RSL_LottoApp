using System;
using System.Net.Http;
using Business.Dto;
using Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RSL_LottoApp.Tests.Controllers
{
    [TestClass]
    public class LottoServiceProviderTest
    {
        private ILottoServiceProvider _lottoServiceProvider;

        [TestInitialize]
        public void Setup()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://data.api.thelott.com")
            };

            _lottoServiceProvider = new LottoServiceProvider(httpClient);
        }

        [TestMethod]
        public void AssertSuccessFlag_IsTrue()
        {
            var drawRequest = new DrawRequest()
            {
                CompanyId = "GoldenCasket",
                MaxDrawCount = 20,
                OptionalProducgtFilter = new[] { "TattsLotto", "MonWedLotto", "OzLotto", "MonWedLotto", "Powerball", "Super66" }
            };

            var results = _lottoServiceProvider.GetOpenDraws(drawRequest).Result;

            // Assert
            Assert.IsTrue(results.Success);
        }

        [TestMethod]
        public void AssertErrorInfo_IsNull()
        {
            var drawRequest = new DrawRequest()
            {
                CompanyId = "GoldenCasket",
                MaxDrawCount = 20,
                OptionalProducgtFilter = new[] { "TattsLotto", "MonWedLotto", "OzLotto", "MonWedLotto", "Powerball", "Super66" }
            };

            var results = _lottoServiceProvider.GetOpenDraws(drawRequest).Result;

            // Assert
            Assert.IsNull(results.ErrorInfo);
        }
    }
}
