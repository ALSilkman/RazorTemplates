using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RazorTemplates.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required(ErrorMessage = "Please enter a ticket name.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Ticket name must be between 6 and 50 characters.")]
        public string TicketName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(500, MinimumLength = 15, ErrorMessage = " Description must be between 15 and 500 characters.")]
        public string TicketDescription { get; set;} = string.Empty;

        [Required(ErrorMessage = "Please enter a sprint number.")]
        [Range(1, 10, ErrorMessage = "Sprint number must be between 1 and 10.")]
        public int? SprintNumber { get; set; }

        [Required(ErrorMessage = "Please enter a point value.")]
        [Range(1,10, ErrorMessage ="Point value must be between 1 and 10")]
        public int? PointValue { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string StatusId { get; set; } = string.Empty;

        [ValidateNever]
        public Status status { get; set; } = null!;
    }
}
