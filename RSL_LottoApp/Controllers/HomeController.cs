﻿using Business.Dto;
using Business.Services;
using RSL_Business.Constants;
using RSL_LottoApp.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace RSL_LottoApp.Controllers
{
    public class HomeController : Controller
    {
        private IOpenDrawsServiceProvider _openDrawsServiceProvider;
        private ILatestResultsServiceProvider _latestResultsServiceProvider;

        public HomeController(IOpenDrawsServiceProvider openDrawsServiceProvider,
            ILatestResultsServiceProvider latestResultsServiceProvider)
        {
            _openDrawsServiceProvider = openDrawsServiceProvider;
            _latestResultsServiceProvider = latestResultsServiceProvider;
        }

        public ActionResult Index()
        {
            var openDrawRequest = new OpenDrawsRequest()
            {
                CompanyId = ConfigurationManager.AppSettings[AppSettingValues.LottoCompanyId],
                MaxDrawCount = 10,
                OptionalProductFilter = new[] { "TattsLotto", "MonWedLotto", "OzLotto", "MonWedLotto", "Powerball", "Super66" }
            };

            var latestResultsRequest = new LatestResultsRequest()
            {
                CompanyId = ConfigurationManager.AppSettings[AppSettingValues.LottoCompanyId],
                MaxDrawCountPerProduct = 10,
                OptionalProductFilter = new[] { "TattsLotto"}
            };

            var viewModel = new Home()
            {
                OpenDrawItems = _openDrawsServiceProvider.GetOpenDraws(openDrawRequest)
                .Result?.Draws.OrderBy(x => x.DrawDate).ToList(),
                LatestResultItems = _latestResultsServiceProvider.GetLatestResults(latestResultsRequest)
                .Result?.DrawResults.OrderBy(x => x.DrawDate).ToList()
            };

            return View(viewModel);
        }
    }
}