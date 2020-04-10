using Business.Dto;
using Business.Services;
using RSL_LottoApp.Models;
using System.Linq;
using System.Web.Mvc;

namespace RSL_LottoApp.Controllers
{
    public class HomeController : Controller
    {
        private ILottoServiceProvider _lottoServiceProivder;

        public HomeController(ILottoServiceProvider lottoServiceProvider)
        {
            _lottoServiceProivder = lottoServiceProvider;
        }

        public ActionResult Index()
        {
            var viewModel = new Home()
            {
                DrawResults = _lottoServiceProivder.GetOpenDraws(new DrawRequest()
                {
                    CompanyId = "GoldenCasket",
                    MaxDrawCount = 20,
                    OptionalProducgtFilter = new[] { "TattsLotto", "MonWedLotto", "OzLotto", "MonWedLotto", "Powerball", "Super66" }
                }).Result?.Draws.OrderBy(x => x.DrawDate).ToList()
            };

            return View(viewModel);
        }
    }
}