using Microsoft.AspNetCore.Mvc;
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

    }
}
