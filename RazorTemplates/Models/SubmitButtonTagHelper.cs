using Microsoft.AspNetCore.Mvc;
using RazorTemplates.Models;

namespace RazorTemplates.Models
{
    public class StatusViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Ticket ticket)
        {
            return View(ticket);
        }
    }
}
