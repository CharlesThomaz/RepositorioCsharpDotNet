using br.com.devset.reclame.Models;
using Microsoft.EntityFrameworkCore;

namespace br.com.devset.reclame.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public virtual DbSet<HospitalModel> Hospitais { get; set; }
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        public virtual DbSet<ReclamacaoModel> Reclamacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HospitalModel>(entity =>
            {
                entity.HasKey(h => h.HospitalId); // Define a chave primária
            });
            modelBuilder.Entity<UsuarioModel>(entity =>
            {
                entity.HasKey(h => h.UsuarioId); // Define a chave primária
                entity.Property(e => e.DataNascimento).HasColumnType("date");
            });

            // Configuração para a entidade Reclamacao
            modelBuilder.Entity<ReclamacaoModel>(entity =>
            {
                // Chave primária
                entity.HasKey(r => r.ReclamacaoId);

                // Relacionamento com HospitalModel
                entity.HasOne(e => e.Hospital)
                    .WithMany() // Um hospital pode ter várias reclamações, sem navegação reversa
                    .HasForeignKey(e => e.HospitalId) // Chave estrangeira correta
                    .OnDelete(DeleteBehavior.Cascade); // Exclui reclamações ao excluir hospital

                // Relacionamento com UsuarioModel
                entity.HasOne(r => r.Usuario)
                    .WithMany() // Um usuário pode ter várias reclamações, sem navegação reversa
                    .HasForeignKey(r => r.UsuarioId) // Chave estrangeira correta
                    .OnDelete(DeleteBehavior.SetNull); // Define null ao excluir usuário
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
