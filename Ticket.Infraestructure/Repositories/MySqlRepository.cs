using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticket.Core.Entities;
using Ticket.Core.Interfaces;

namespace Ticket.Infraestructure.Repositories
{
    public class MySqlRepository : ITicketRepository
    {
        public Task<bool> DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tickete>> GetTickets()
        {
            
                var tickets = Enumerable.Range(1, 10).Select(x => new Tickete
                {
                    IdTicket = x,
                    UsuarioId = x * 2,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    Estatus = "Abierto"
                });
                await Task.Delay(10);
                return tickets;
        }

        public Task InsertTicket(Tickete ticket)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTicket(Tickete t)
        {
            throw new NotImplementedException();
        }

        Task<Tickete> ITicketRepository.GetTicket(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}
