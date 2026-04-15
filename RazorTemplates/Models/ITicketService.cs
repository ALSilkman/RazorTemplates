namespace RazorTemplates.Models
{
    public interface ITicketService
    {
        List<Ticket> GetTickets(Filters filter);
        List<Status> GetStatuses();
        void AddTicket(Ticket ticket);
        void MarkComplete(int  ticketId);
        void DeleteCompleted();
    }
}
