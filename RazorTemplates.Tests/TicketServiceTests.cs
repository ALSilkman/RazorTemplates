using Xunit;
using Microsoft.EntityFrameworkCore;
using RazorTemplates.Models;

namespace RazorTemplates.Tests.Services
{
    public class TicketServiceTests
    {
        private TicketContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<TicketContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new TicketContext(options);
        }

        [Fact]
        public void AddTicket_AddsToDatabase()
        {
            // Arrange
            var context = GetDbContext();
            var service = new TicketService(context);

            var ticket = new Ticket
            {
                TicketName = "Test Ticket",
                TicketDescription = "Unit Test Ticket",
                SprintNumber = 1,
                PointValue = 5,
                StatusId = "todo"
            };

            // Act
            service.AddTicket(ticket);

            // Assert
            Assert.Equal(1, context.Tickets.Count());
        }

        [Fact]
        public void MarkComplete_UpdatesStatus()
        {
            // Arrange
            var context = GetDbContext();

            context.Tickets.Add(new Ticket
            {
                TicketId = 1,
                TicketName = "Test Ticket",
                TicketDescription = "Unit test",
                SprintNumber = 1,
                PointValue = 5,
                StatusId = "todo"
            });

            context.SaveChanges();

            var service = new TicketService(context);

            // Act
            service.MarkComplete(1);

            // Assert
            var ticket = context.Tickets.Find(1);
            Assert.Equal("done", ticket.StatusId);
        }

        [Fact]
        public void DeleteCompleted_RemovesOnlyDoneTickets()
        {
            // Arrange
            var context = GetDbContext();

            context.Tickets.AddRange(
                new Ticket
                {
                    TicketName = "Done Ticket",
                    TicketDescription = "Test",
                    SprintNumber = 1,
                    PointValue = 5,
                    StatusId = "done"
                },
                new Ticket
                {
                    TicketName = "Todo Ticket",
                    TicketDescription = "Test",
                    SprintNumber = 1,
                    PointValue = 5,
                    StatusId = "todo"
                }
            );

            context.SaveChanges();

            var service = new TicketService(context);

            // Act
            service.DeleteCompleted();

            // Assert
            Assert.Single(context.Tickets);
            Assert.Equal("todo", context.Tickets.First().StatusId);
        }
    }
}
