using br.com.devset.reclame.Data;
using br.com.devset.reclame.Models;
using Microsoft.AspNetCore.Mvc;

namespace br.com.devset.reclame.Controllers
{
    public class UsuarioController : Controller
    {


        private readonly DatabaseContext _databaseContext;



        public UsuarioController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;


        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(UsuarioModel usuarioModel)
        {
            _databaseContext.Usuarios.Add(usuarioModel);
            _databaseContext.SaveChanges();

            TempData["mensagemSucesso"] = "Usuario Cadastrado!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            var _usuarios = _databaseContext.Usuarios.ToList();
            return View(_usuarios);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var usuario = _databaseContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound("Usuario não existe no sistema!");
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var usuario = _databaseContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound("Usuario não existe no sistema!");
            }
            _databaseContext.Remove(usuario);
            _databaseContext.SaveChanges();
            TempData["mensagemSucesso"] = "Usuario deletado!";
            return RedirectToAction(nameof(Index));
        }
         [HttpGet]
        public IActionResult Edit(int id)
        {
            

            var usuarioEditar = _databaseContext.Usuarios.Find(id);
            if (usuarioEditar == null)
            {
                return NotFound("Usuario não existe no sistema!");
            }
            return View(usuarioEditar);
        }
        [HttpPost]
        public IActionResult Edit(UsuarioModel usuarioModel)
        {
            
                _databaseContext.Usuarios.Update(usuarioModel);
                _databaseContext.SaveChanges();

                TempData["mensagemSucesso"] = $"Usuário {usuarioModel.Nome} atualizado!";
                return RedirectToAction(nameof(Index));
            

            return View(usuarioModel);
        }


        [HttpGet]
        public IActionResult Listar(int id)
        {
            // Obtém a lista de reclamações do hospital com o id fornecido
            var lista = _databaseContext.Reclamacoes
                .Where(r => r.UsuarioId == id)
                .ToList();

            if (lista.Count == 0)
            {
                return Json(new { mensagem = "Lista Vazia" });
            }
            else
            {
                // Inicializa a lista de descrições
                List<string> listaDesc = new List<string>();
                var i = 1;

                // Adiciona as descrições de cada reclamação na lista
                foreach (var item in lista)
                {
                    listaDesc.Add($"Reclamação {i}: {item.Descricao}");
                    i++;
                }
                
                // Retorna a lista de descrições e o número de reclamações em formato JSON
                return Json(new { listaDescricoes = listaDesc, numReclamacoes = listaDesc.Count });
            }
        }



    }
}
