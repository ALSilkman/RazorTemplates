using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RazorTemplates.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        public string TicketName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        public string TicketDescription { get; set;} = string.Empty;

        [Required(ErrorMessage = "Please enter a sprint number.")]
        public int? SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter a point value.")]
        public int? PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; } = string.Empty;

        [ValidateNever]
        public Status status { get; set; } = null!;
    }
}
