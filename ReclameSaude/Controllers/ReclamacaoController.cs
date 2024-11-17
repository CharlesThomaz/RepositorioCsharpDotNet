using br.com.devset.ReclameSaude.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using br.com.devset.reclameReclameSaude.Controllers;


namespace br.com.devset.ReclameSaude.Controllers
{
    public class ReclamacaoController : Controller
    {
        private List<ReclamacaoModel> lista;
        private List<UsuarioModel> usuarios;
        private List<HospitalModel> hospitais;

        public ReclamacaoController()
        {
            // Inicializando os campos da classe corretamente
            usuarios = UsuarioController.GerarUsuarios();
            hospitais = HospitalController.GerarHospital();
            lista = GerarReclamacao();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Usuarios = new SelectList(usuarios, "UsuarioId", "Nome");
            ViewBag.Hospitais = new SelectList(hospitais, "HospitalId", "Nome");
            return View();
        }

        [HttpPost]
        public IActionResult Create(ReclamacaoModel reclamacaoModel)
        {
            lista.Add(reclamacaoModel); // Adiciona a nova reclamação na lista
            TempData["mensagemSucesso"] = "Reclamação cadastrada!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Hospitais = new SelectList(hospitais, "HospitalId", "Nome");
            ViewBag.Usuarios = new SelectList(usuarios, "UsuarioId", "Nome");

            var reclamacaoConsultada = lista.FirstOrDefault(r => r.ReclamacaoId == id);

            if (reclamacaoConsultada == null)
            {
                return NotFound();
            }

            return View(reclamacaoConsultada);
        }

        [HttpPost]
        public IActionResult Edit(ReclamacaoModel reclamacaoModel)
        {
            var reclamacaoUpdate = reclamacaoModel;
            if (reclamacaoUpdate == null)
            {
                return NotFound("Reclamacão vazia!");

            }
            

            TempData["mensagemSucesso"] = "Reclamação atualizada com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var reclamacaoConsultada = lista.FirstOrDefault(r => r.ReclamacaoId == id);

            if (reclamacaoConsultada == null)
            {
                return NotFound();
            }

            return View(reclamacaoConsultada);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var reclamacaoExcluir = lista.FirstOrDefault(r => r.ReclamacaoId == id);

            if (reclamacaoExcluir == null)
            {
                return NotFound();
            }

            lista.Remove(reclamacaoExcluir);
            TempData["mensagemSucesso"] = $"Reclamação {id} deletada!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View(lista);
        }

        public static List<ReclamacaoModel> GerarReclamacao()
        {
            var listaReclamacao = new List<ReclamacaoModel>();

            for (int i = 1; i <= 5; i++)
            {
                var usuario = new UsuarioModel { UsuarioId = i, Nome = $"User {i}" };
                var hospital = new HospitalModel { HospitalId = i, Nome = $"Hosp {i}" };

                var reclamacao = new ReclamacaoModel
                {
                    ReclamacaoId = i,
                    Descricao = $"Reclamação {i}",
                    Usuario = usuario,
                    Hospital = hospital
                };

                listaReclamacao.Add(reclamacao);
            }
            return listaReclamacao;
        }
    }
}
