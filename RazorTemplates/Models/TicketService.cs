using Microsoft.EntityFrameworkCore;
namespace RazorTemplates.Models
{
    public class TicketService : ITicketService
    {
        private readonly TicketContext _context;

        public TicketService(TicketContext context)
        {
            _context = context;
        }

        public List<Ticket> GetTickets(Filters filters)
        {
            var query = _context.Tickets
                .Include(t => t.status)
                .AsQueryable();

            if (filters.HasSprint)
            {
                int sprint = int.Parse(filters.Sprint);
                query = query.Where(t => t.SprintNumber == sprint);
            }

            if (filters.HasStatus)
            {
                query = query.Where(t => t.StatusId == filters.StatusId);
            }

            return query.OrderBy(t => t.SprintNumber).ToList();
        }

        public List<Status> GetStatuses()
        {
            return _context.Statuses.ToList();
        }

        public void AddTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void MarkComplete(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket != null) {
                ticket.StatusId = "done";
                _context.SaveChanges();
            }
        }

        public void DeleteCompleted()
        {
            var completed = _context.Tickets
                .Where(t => t.StatusId == "done")
                .ToList();

            _context.Tickets.RemoveRange(completed);
            _context.SaveChanges();
        }
    }
}
