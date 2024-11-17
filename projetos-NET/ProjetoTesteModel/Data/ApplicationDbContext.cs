using Microsoft.EntityFrameworkCore;
using ProjetoTesteModel.Models;

namespace ProjetoTesteModel.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Construtor sem parâmetros para migrações
        public ApplicationDbContext() { }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
