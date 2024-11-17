using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using br.com.devset.reclame.Data;
using br.com.devset.reclame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace br.com.devset.reclame.Controllers
{
    public class HospitalController : Controller
    {

        private readonly DatabaseContext _databaseContext;


        public HospitalController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IActionResult Index()
        {
            var _hospitais = _databaseContext.Hospitais.ToList();

            return View(_hospitais);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalModel hospitalModel)
        {
            _databaseContext.Hospitais.Add(hospitalModel);
            _databaseContext.SaveChanges();

            TempData["mensagemSucesso"] = "Hospital cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hospital = _databaseContext.Hospitais.Find(id);
            if (hospital == null)
            {
                return NotFound("Hospital não cadastrado no sistema!");
            }
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(HospitalModel hospitalModel)
        {
            _databaseContext.Hospitais.Update(hospitalModel);
            _databaseContext.SaveChanges();


            TempData["mensagemSucesso"] = $"Hospital {hospitalModel.Nome} atualizado!";

            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hospital = _databaseContext.Hospitais.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }

            _databaseContext.Hospitais.Remove(hospital);
            _databaseContext.SaveChanges();
            TempData["mensagemSucesso"] = "Hospital deletado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var hospital = _databaseContext.Hospitais.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }


        [HttpGet]
        public IActionResult Listar(int id)
        {
            // Obtém a lista de reclamações do hospital com o ID fornecido
            var lista = _databaseContext.Reclamacoes
                .Where(r => r.HospitalId == id)
                .ToList();

            if (lista.Count == 0)
            {
                // Retorna uma mensagem JSON se não houver reclamações
                return Json(new { mensagem = "Lista Vazia" });
            }
            else
            {
                // Configura o ViewBag para exibir os dados na View
                ViewBag.NumRec = lista.Count;
                ViewBag.Rec = lista;

                // Retorna a View
                return View();
            }
        }


    }



}




