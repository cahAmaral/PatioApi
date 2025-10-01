using Microsoft.EntityFrameworkCore;
using PatioApi.Models;

namespace PatioApi.Data
{
    public class PatioContext : DbContext
    {
        public PatioContext(DbContextOptions<PatioContext> options) : base(options) { }

        public DbSet<Moto> Motos { get; set; }
        public DbSet<Operador> Operadores { get; set; }
        public DbSet<Movimentacao> Movimentacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.HasDefaultSchema("RM558012"); 
            
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.ToTable("MOTO"); 
                entity.HasKey(e => e.Id); // ID_MOTO

                entity.Property(e => e.Id)
                    .HasColumnName("ID_MOTO");

                entity.Property(e => e.Placa)
                    .HasColumnName("MT_PLACA");

                entity.Property(e => e.Status)
                    .HasColumnName("MT_STATUS");

                entity.Property(e => e.IdModelo)
                    .HasColumnName("ID_MODELO");
            });

        }
    }
}