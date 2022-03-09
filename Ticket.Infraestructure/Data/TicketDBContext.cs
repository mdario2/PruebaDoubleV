using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ticket.Core.Entities;

#nullable disable

namespace Ticket.Infraestructure.Data
{
    public partial class TicketDBContext : DbContext
    {
        public TicketDBContext()
        {
        }

        public TicketDBContext(DbContextOptions<TicketDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tickete> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UT77TD2\\SQLEXPRESS;Database=TicketDB;Integrated Security = true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tickete>(entity =>
            {
                entity.HasKey(e => e.IdTicket);

                entity.ToTable("Tickete");

                entity.Property(e => e.IdTicket).ValueGeneratedNever();

                entity.Property(e => e.Estatus)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");

                entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
            });

            
        }
        
    }
}
