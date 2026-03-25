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
        }

    }
}
