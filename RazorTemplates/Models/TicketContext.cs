using Microsoft.EntityFrameworkCore;
namespace RazorTemplates.Models

{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "todo", StatusName = "To Do" },
                new Status { StatusId = "inprogress", StatusName = "In Progress" },
                new Status { StatusId = "qa", StatusName = "Quality Assurance" },
                new Status { StatusId = "done", StatusName = "Done" });

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, TicketName = "Build Controllers", TicketDescription = "Build Controllers for project", SprintNumber = 1, PointValue = 5, StatusId = "done" },
                new Ticket { TicketId = 2, TicketName = "Build Models", TicketDescription = "Code all models for project", SprintNumber = 2, PointValue = 10, StatusId = "todo" },
                new Ticket { TicketId = 3, TicketName = "Complete Program.cs", TicketDescription = "Code Program.cs in project", SprintNumber = 3, PointValue = 8, StatusId = "todo" },
                new Ticket { TicketId = 4, TicketName = "Images Folder", TicketDescription = "Make images folder and add images", SprintNumber = 3, PointValue = 5, StatusId = "inprogress" },
                new Ticket { TicketId = 5, TicketName = "Unit Testing", TicketDescription = "Code unit tests for project", SprintNumber = 4, PointValue = 10, StatusId = "qa" });                
 
        
        }

        

    }
}
