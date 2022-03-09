using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Entities;
using Ticket.Core.Interfaces;
using Ticket.Infraestructure.Data;

namespace Ticket.Infraestructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketDBContext mycontext;
        public TicketRepository(TicketDBContext context)
        {
            mycontext = context;
        }

        public async Task<IEnumerable<Tickete>> GetTickets()
        {
            var ticketes = await mycontext.Tickets.ToListAsync();
            return ticketes;
        }

        public async Task<Tickete> GetTicket(int id)
        {
            var ticketes = await mycontext.Tickets.FirstOrDefaultAsync(x => x.IdTicket == id);
            return ticketes;
        }

        public async Task InsertTicket(Tickete ticket)
        {
            mycontext.Tickets.Add(ticket);
            await mycontext.SaveChangesAsync();
        }

        public async Task<bool> UpdateTicket(Tickete t)
        {
            var aux = await GetTicket(t.IdTicket);
            aux.FechaActualizacion = t.FechaActualizacion;
            aux.Estatus = t.Estatus;

            int rows = await mycontext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteTicket(int id)
        {
            var aux = await GetTicket(id);
            mycontext.Tickets.Remove(aux);

            int rows = await mycontext.SaveChangesAsync();
            return rows > 0;
        }


    }
}
