using Microsoft.AspNetCore.Mvc;
using RazorTemplates.Models;
using System.Runtime.ExceptionServices;

namespace RazorTemplates.Controllers
{
    
    public class Assignment61Controller : Controller
    {

        [HttpGet("/Assignment61/{accessLevel:int}")]
        public IActionResult Index(int accessLevel)
        {
            if (accessLevel < 1 || accessLevel > 10)
            {

                return BadRequest("Access level must be between 1 and 10.");
            }

            var students = new List<Student>
            {
                new Student { Id = 1, FirstName = "Amanda", LastName = "Silkman", Grade = .995},
                new Student { Id = 2, FirstName = "Zach", LastName = "Dredge", Grade = .8595},
                new Student { Id = 3, FirstName = "Kaitlynn", LastName = "Cranor", Grade = .91},
                new Student { Id = 4, FirstName = "Nick", LastName = "Goforth", Grade = .7859}

            };

            var viewModel = new Assignment61View
            {
                AccessLevel = accessLevel,
                Students = students
            };

            return View(viewModel);
        }

        [HttpGet("/Assignment61/Details/{id:int}")]
        public IActionResult Details(int id)
        {
            return Content($"Student Details Page for ID: {id}");
        }
    }
}
