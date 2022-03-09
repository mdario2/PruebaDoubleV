using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Entities;

namespace Ticket.Core.Interfaces
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Tickete>> GetTickets();
        Task<Tickete> GetTicket(int id);

        Task InsertTicket(Tickete ticket);

        Task<bool> UpdateTicket(Tickete t);

        Task<bool> DeleteTicket(int id);


    }
}
