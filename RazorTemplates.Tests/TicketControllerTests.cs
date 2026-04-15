using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using RazorTemplates.Controllers;
using RazorTemplates.Models;

namespace RazorTemplates.Tests.Controllers
{
    public class TicketControllerTests
    {
        [Fact]
        public void Add_ValidTicket_RedirectsToIndex()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            var controller = new TicketController(mockService.Object);

            var ticket = new Ticket { TicketName = "Test Ticket" };

            // Act
            var result = controller.Add(ticket);

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            mockService.Verify(s => s.AddTicket(ticket), Times.Once);
        }

        [Fact]
        public void Add_InvalidModel_ReturnsView()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            var controller = new TicketController(mockService.Object);

            controller.ModelState.AddModelError("error", "invalid");

            var ticket = new Ticket();

            // Act
            var result = controller.Add(ticket);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void MarkComplete_CallsService()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            var controller = new TicketController(mockService.Object);

            var ticket = new Ticket { TicketId = 1 };

            // Act
            controller.MarkComplete("all", ticket);

            // Assert
            mockService.Verify(s => s.MarkComplete(1), Times.Once);
        }

        [Fact]
        public void DeleteComplete_CallsService()
        {
            // Arrange
            var mockService = new Mock<ITicketService>();
            var controller = new TicketController(mockService.Object);

            // Act
            controller.DeleteComplete("all");

            // Assert
            mockService.Verify(s => s.DeleteCompleted(), Times.Once);
        }
    }
}
