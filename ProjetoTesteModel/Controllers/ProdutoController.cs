using Microsoft.AspNetCore.Mvc;
using ProjetoTesteModel.Data;
using ProjetoTesteModel.Models;

namespace ProjetoTesteModel.Controllers
{
    [Route("produto")]
    public class ProdutoController : Controller
    {
        private readonly ApplicationDbContext context;

        public ProdutoController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // Ação para exibir a página inicial (se necessário)
        public IActionResult Index()
        {
            return View();
        }

        // Ação para criar um produto via POST
        [HttpPost("create")]
        public IActionResult Create([FromBody] ProdutoModel produtoModel)
        {
            if (produtoModel == null || string.IsNullOrEmpty(produtoModel.Nome))
            {
                return BadRequest("O campo 'Nome' é obrigatório.");
            }

            // Adiciona o produto ao contexto e salva no banco
            context.Add(produtoModel);
            context.SaveChanges();

            Console.WriteLine("Produto Salvo");

            return Ok(produtoModel);  // Retorna o produto criado em formato JSON
        }
    }
}
