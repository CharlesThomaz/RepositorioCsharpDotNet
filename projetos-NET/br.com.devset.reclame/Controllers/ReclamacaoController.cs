using br.com.devset.reclame.Data;
using br.com.devset.reclame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore; // Para usar o Include
using System.Linq;

namespace br.com.devset.reclame.Controllers
{
    public class ReclamacaoController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public ReclamacaoController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        // Ação para exibir a lista de reclamações
        public IActionResult Index()
        {
            var reclamacoes = _databaseContext.Reclamacoes
                .Include(r => r.Usuario)  // Incluindo a entidade Usuario
                .Include(r => r.Hospital) // Incluindo a entidade Hospital
                .ToList();

            return View(reclamacoes);
        }

        // Ação para exibir o formulário de criação de reclamação
        [HttpGet]
        public IActionResult Create()
        {
            var usuarios = _databaseContext.Usuarios.ToList();
            var hospitais = _databaseContext.Hospitais.ToList();

            // Preenchendo o ViewBag para os selects
            ViewBag.Usuarios = new SelectList(usuarios, "UsuarioId", "Nome");
            ViewBag.Hospitais = new SelectList(hospitais, "HospitalId", "Nome");

            return View();
        }

        // Ação para processar a criação de uma nova reclamação
        [HttpPost]
        public IActionResult Create(ReclamacaoModel reclamacaoModel)
        {
          
                _databaseContext.Reclamacoes.Add(reclamacaoModel);
                _databaseContext.SaveChanges();

                TempData["mensagemSucesso"] = "Reclamação cadastrada!";
            

            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Obtém a reclamação pelo ID
            var reclamacaoConsultada = _databaseContext.Reclamacoes
                .Include(r => r.Usuario)
                .Include(r => r.Hospital)
                .FirstOrDefault(r => r.ReclamacaoId == id);

            if (reclamacaoConsultada == null)
            {
                return NotFound("Reclamação não encontrada.");
            }

            // Preenchendo a ViewBag para os selects
            var usuarios = _databaseContext.Usuarios.ToList();
            var hospitais = _databaseContext.Hospitais.ToList();

            ViewBag.Usuarios = new SelectList(usuarios, "UsuarioId", "Nome", reclamacaoConsultada.UsuarioId);
            ViewBag.Hospitais = new SelectList(hospitais, "HospitalId", "Nome", reclamacaoConsultada.HospitalId);

            return View(reclamacaoConsultada);
        }


        [HttpPost]
        public IActionResult Edit(ReclamacaoModel reclamacaoModel)
        {
            if (ModelState.IsValid)
            {
                // Atualiza o objeto no banco
                _databaseContext.Reclamacoes.Update(reclamacaoModel);
                _databaseContext.SaveChanges();

                TempData["mensagemSucesso"] = $"Reclamação {reclamacaoModel.ReclamacaoId} atualizada com sucesso!";
                return RedirectToAction(nameof(Index));
            }

            // Preenche novamente os dados para exibir o formulário em caso de erro
            ViewBag.Usuarios = new SelectList(_databaseContext.Usuarios, "UsuarioId", "Nome", reclamacaoModel.UsuarioId);
            ViewBag.Hospitais = new SelectList(_databaseContext.Hospitais, "HospitalId", "Nome", reclamacaoModel.HospitalId);

            return View(reclamacaoModel);
        }






        // Ação para exibir os detalhes de uma reclamação
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var reclamacaoConsultada = _databaseContext.Reclamacoes
                .Include(r => r.Usuario)
                .Include(r => r.Hospital)
                .FirstOrDefault(r => r.ReclamacaoId == id);

            if (reclamacaoConsultada == null)
            {
                return NotFound();
            }

            return View(reclamacaoConsultada);
        }

        // Ação para excluir uma reclamação
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var reclamacaoExcluir = _databaseContext.Reclamacoes.Find(id);

            if (reclamacaoExcluir == null)
            {
                return NotFound();
            }

            _databaseContext.Reclamacoes.Remove(reclamacaoExcluir);
            _databaseContext.SaveChanges();
            TempData["mensagemSucesso"] = $"Reclamação {id} deletada!";
            return RedirectToAction(nameof(Index));
        }
    }
}
