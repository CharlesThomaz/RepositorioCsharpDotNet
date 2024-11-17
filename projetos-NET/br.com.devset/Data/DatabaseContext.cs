using br.com.devset.Models;
using Microsoft.EntityFrameworkCore;

namespace br.com.devset.Data
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<RepresentanteModel> Representantes { get; set; }
        public virtual DbSet<ClienteModel> Clientes { get; set; }


        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RepresentanteModel>(entity =>
            {
                entity.ToTable("Representates");
                entity.HasKey(e => e.RepresentanteId);
                entity.Property(e => e.NomeRepresentante).IsRequired();
                entity.HasIndex(e => e.Cpf).IsUnique();

            });

            modelBuilder.Entity<ClienteModel>(entity =>
            {
                entity.ToTable("Clientes");
                entity.HasKey(e => e.ClienteId);
                entity.Property(e => e.Nome).IsRequired();
                entity.Property(e => e.Email).IsRequired();


                entity.Property(e => e.DataNascimento).HasColumnType("date");
                entity.Property(e => e.Observacao).HasMaxLength(500);

                entity.HasOne(e => e.Representante)
                    .WithMany()
                    .HasForeignKey(e => e.RepresentanteId)
                    .IsRequired();
                }
                
            );
        }





    }
}
