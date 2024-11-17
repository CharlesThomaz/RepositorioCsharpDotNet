using br.com.devset.ReclameSaude.Models;
using Microsoft.AspNetCore.Mvc;


namespace br.com.devset.ReclameSaude.Controllers
{
    public class HospitalController : Controller
    {
        private List<HospitalModel> hospitalModels;

        public HospitalController()
        {
            hospitalModels = GerarHospital();
        }

        public IActionResult Index()
        {
            return View(hospitalModels);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(HospitalModel hospitalModel)
        {
            // Adiciona o novo hospital à lista
            hospitalModel.HospitalId = hospitalModels.Max(h => h.HospitalId) + 1;
            hospitalModels.Add(hospitalModel);

            TempData["mensagemSucesso"] = "Hospital cadastrado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var hospital = hospitalModels.FirstOrDefault(h => h.HospitalId == id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(HospitalModel hospitalModel)
        {
            var hospitalUpdate = hospitalModel;
            if (hospitalUpdate == null)
            {
                return NotFound("Usuario vazio!");

            }
            TempData["mensagemSucesso"] = "Hospital atualizado!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var hospital = hospitalModels.FirstOrDefault(h => h.HospitalId == id);
            if (hospital == null)
            {
                return NotFound();
            }

            hospitalModels.Remove(hospital);
            TempData["mensagemSucesso"] = "Hospital deletado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var hospital = hospitalModels.FirstOrDefault(h => h.HospitalId == id);
            if (hospital == null)
            {
                return NotFound();
            }
            return View(hospital);
        }

        public static List<HospitalModel> GerarHospital()
        {
            var listaHospitais = new List<HospitalModel>();
            for (int i = 1; i <= 5; i++)
            {
                HospitalModel hospital = new HospitalModel
                {
                    HospitalId = i,
                    Endereco = "Endereço " + i,
                    Nome = "Hospital " + i
                };
                listaHospitais.Add(hospital);
            }
            return listaHospitais;
        }
    }
}
