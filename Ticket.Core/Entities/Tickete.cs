using System;
using System.Collections.Generic;

#nullable disable

namespace Ticket.Core.Entities
{//tabla BD
    public partial class Tickete
    {
        public int IdTicket { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public string Estatus { get; set; }
    }
}
