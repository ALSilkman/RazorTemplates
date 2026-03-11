using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazorTemplates.Models;
using System.Runtime.ExceptionServices;

namespace RazorTemplates.Controllers
{
    public class DataTransferController : Controller
    {
        private CountryContext context;

        public DataTransferController(CountryContext ctx)
        {
            context = ctx;
        }

        public ViewResult Index(CountriesViewModel model)
        {
            var session = new OlympicSession(HttpContext.Session);
            session.SetActiveGame(model.ActiveGame);
            session.SetActiveCate(model.ActiveCate);
            model.Games = context.Games.ToList();
            model.Categories = context.Categories.ToList();

            IQueryable<Country> query = context.Countries.OrderBy(c => c.CountryName);
            if (model.ActiveGame != "all")
                query = query.Where(
                    g => g.Game.GameId.ToLower() == model.ActiveGame.ToLower());

            if (model.ActiveCate != "all")
                query = query.Where(
                    t => t.Category.CategoryId.ToLower() == model.ActiveCate.ToLower());

            model.Countries = query.ToList();
            return View(model);
        }

        public ViewResult Details(string id)
        {
            var session = new OlympicSession(HttpContext.Session);
            var model = new CountriesViewModel
            {
                Country = context.Countries
                    .Include(t => t.Game)
                    .Include(t => t.Category)
                    .FirstOrDefault(t => t.CountryId == id) ?? new Country(),
                ActiveGame = session.GetActiveGame(),
                ActiveCate = session.GetActiveCate()
            };
            return View(model);
        }


    }
}
