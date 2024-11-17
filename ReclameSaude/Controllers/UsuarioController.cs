using br.com.devset.ReclameSaude.Models;
using Microsoft.AspNetCore.Mvc;

namespace br.com.devset.reclameReclameSaude.Controllers
{
    public class UsuarioController : Controller
    {
        private  List<UsuarioModel>  _usuarios;


        public UsuarioController()
        {
            
            _usuarios = GerarUsuarios();


        }




        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Create(UsuarioModel usuarioModel)
        {             
            TempData["mensagemSucesso"] = "Usuario Cadastrado!";
            return View(new UsuarioModel());
        }

        public IActionResult Index()
        {
            Console.WriteLine(_usuarios.Count);
            return View(_usuarios);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound("Usuario não existe no sistema!");
            }
            return View(usuario);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var usuario = _usuarios.FirstOrDefault(u => u.UsuarioId == id);
            if (usuario == null)
            {
                return NotFound("Usuario não existe no sistema!");
            }
            TempData["mensagemSucesso"] = "Usuario deletado!";
            return RedirectToAction(nameof(Index));
        }
         [HttpGet]
        public IActionResult Edit(int id)
        {
            var usuarioEditar = _usuarios.FirstOrDefault(u => u.UsuarioId == id);
            if (usuarioEditar == null)
            {
                return NotFound("Usuario não existe no sistema!");
            }
            return View(usuarioEditar);
        } 
        [HttpPost]
        public IActionResult Edit(UsuarioModel usuarioModel)
        {
            var usuarioUpdate = usuarioModel;
            if (usuarioUpdate == null)
            {
                return NotFound("Usuario vazio!");

            }
            TempData["mensagemSucesso"] = "Usuário atualizado!";
            return RedirectToAction(nameof(Index));
        }



        public static List<UsuarioModel> GerarUsuarios()
        {
            var listaUsuarios = new List<UsuarioModel>();
            for (int i=1; i <= 5; i++)
            {
                UsuarioModel u = new UsuarioModel();
                u.UsuarioId = i;
                u.WatsApp = "zap" + i;
                u.Nome = "user"+i;
                u.Email = $"user{i}@email.com";
                u.DataNascimento = DateTime.Now;
                u.Senha = "senha"+i;
                listaUsuarios.Add(u);
            }
            return listaUsuarios;
        }
    }
}
