using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorTemplates.Models;

namespace RazorTemplates.Controllers
{
    public class FavoritesController : Controller
    {

        private CountryContext context;
        public FavoritesController(CountryContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index()
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                ActiveGame = session.GetActiveGame(),
                ActiveCate = session.GetActiveCate(),
                Countries = session.GetMyCountries(),
            };
            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(Country country)
        {
            country = context.Countries
                .Include(t => t.Game)
                .Include(t => t.Category)
                .Where(t => t.CountryId == country.CountryId)
                .FirstOrDefault() ?? new Country();

            var session = new OlympicSession(HttpContext.Session);
            var countries = session.GetMyCountries();
            countries.Add(country);
            session.SetMyCountries(countries);

            TempData["message"] = $"{country.CountryName} added to your favorites";
            return RedirectToAction("Index", "DataTransfer",
                new
                {
                    ActiveGame = session.GetActiveGame() ,
                    ActiveCate = session.GetActiveCate()
                });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new OlympicSession(HttpContext.Session);
            session.RemoveMyCountries();

            TempData["message"] = "Favorite countries cleared";
            return RedirectToAction("Index", "DataTransfer",
                new
                {
                    ActiveGame = session.GetActiveGame(),
                    ActiveCate = session.GetActiveCate()
                });
        }

    }
}
