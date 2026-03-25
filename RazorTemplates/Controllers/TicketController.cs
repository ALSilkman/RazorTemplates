using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorTemplates.Models;

namespace RazorTemplates.Controllers
{
    public class TicketController : Controller
    {
        private TicketContext context;

        public TicketController(TicketContext ctx) => context = ctx;

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);
            ViewBag.Filters = filters;
            ViewBag.Statuses = context.Statuses.ToList();

            ViewBag.Sprints = new SelectList(
                Enumerable.Range(1, 10).Select(i => new { Value = i, Text = $"Sprint {i}" }),
                "Value", "Text",
                filters.Sprint);

            IQueryable<Ticket> query = context.Tickets.Include(t => t.status);

            if (filters.HasSprint)
            {
                int sprint = int.Parse(filters.Sprint);
                query = query.Where(t => t.SprintNumber == sprint);
            }

            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }

            var tickets = query.OrderBy(t => t.SprintNumber).ToList();

            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = context.Statuses.ToList();

            var ticket = new Ticket { StatusId = "todo" };
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Statuses = context.Statuses.ToList();
                return View(ticket);
            }
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { id = id });
        }

        [HttpPost]
        public IActionResult MarkComplete([FromRoute] string id, Ticket selected)
        {
            selected = context.Tickets.Find(selected.TicketId)!;

            if (selected != null)
            {
                selected.StatusId = "done";
                context.SaveChanges();
            }

            return RedirectToAction("Index", new {id = id});
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            var toDelete = context.Tickets.Where(t => t.StatusId == "done").ToList();

            foreach (var ticket in toDelete)
            {
                context.Tickets.Remove(ticket);
            }
            context.SaveChanges();

            return RedirectToAction("Index", new {id = id});
        }
    }
}
