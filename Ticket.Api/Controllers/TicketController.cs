using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Ticket.Core.Entities;
using Ticket.Core.Interfaces;

namespace Ticket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository myTicketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            myTicketRepository = ticketRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTickets()
        {
            var ticketes = await myTicketRepository.GetTickets();
            return Ok(ticketes);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            var ticket = await myTicketRepository.GetTicket(id);
            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tickete t )
        {
            await myTicketRepository.InsertTicket(t);
            return Ok(t);
        }
        [HttpPut]
        public async Task<IActionResult> Put(int id, Tickete t)
        {
            t.IdTicket = id;
            await myTicketRepository.UpdateTicket(t);
            return Ok(t);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await myTicketRepository.DeleteTicket(id);
            return Ok(result);
        }

    }
}
