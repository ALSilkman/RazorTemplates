using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorTemplates.Models;

namespace RazorTemplates.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        public IActionResult Index(string id)
        {
            var filters = new Filters(id);

            ViewBag.Filters = filters;
            ViewBag.Statuses = _service.GetStatuses();

            ViewBag.Sprints = new SelectList(
                Enumerable.Range(1, 10)
                    .Select(i => new { Value = i, Text = $"Sprint {i}" }),
                "Value", "Text",
                filters.Sprint);

            var tickets = _service.GetTickets(filters);

            return View(tickets);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Statuses = _service.GetStatuses();
            return View(new Ticket { StatusId = "todo" });
        }

        [HttpPost]
        public IActionResult Add(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _service.AddTicket(ticket);
                return RedirectToAction("Index");
            }

            ViewBag.Statuses = _service.GetStatuses();
            return View(ticket);
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            string id = string.Join('-', filter);
            return RedirectToAction("Index", new { id });
        }

        [HttpPost]
        public IActionResult MarkComplete(string id, Ticket selected)
        {
            _service.MarkComplete(selected.TicketId);
            return RedirectToAction("Index", new { id });
        }

        [HttpPost]
        public IActionResult DeleteComplete(string id)
        {
            _service.DeleteCompleted();
            return RedirectToAction("Index", new { id });
        }
    }
}