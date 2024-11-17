using br.com.devset.ReclameSaude.Models;
using Microsoft.EntityFrameworkCore;

namespace br.com.devset.ReclameSaude.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<HospitalModel> Hospitais { get; set; }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<ReclamacaoModel> Reclamacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar as relações entre as entidades

            modelBuilder.Entity<ReclamacaoModel>()
                .HasOne(r => r.Hospital)
                .WithMany() // Relacionamento de muitos hospitais para muitas reclamações
                .HasForeignKey(r => r.HospitalId)  // Usar a propriedade HospitalId como chave estrangeira
                .OnDelete(DeleteBehavior.Cascade); // Configurar comportamento de exclusão em cascata (caso necessário)

            modelBuilder.Entity<ReclamacaoModel>()
                .HasOne(r => r.Usuario)
                .WithMany() // Relacionamento de muitos usuários para muitas reclamações
                .HasForeignKey(r => r.UsuarioId)  // Usar a propriedade UsuarioId como chave estrangeira
                .OnDelete(DeleteBehavior.SetNull); // Se o usuário for excluído, setar null nas reclamações associadas (se necessário)

            base.OnModelCreating(modelBuilder);
        }
    }
}
