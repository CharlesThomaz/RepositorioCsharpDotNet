using br.com.devset.Data;
using br.com.devset.Models; // Certifique-se que os usings estão corretos.
using Microsoft.AspNetCore.Mvc;


namespace br.com.devset.Controllers
{
    public class ClienteController : Controller
    {
        private IList<ClienteModel> clientes { get; set; }
        private IList<RepresentanteModel> representantes { get; set; }



        private readonly DatabaseContext _databaseContext;


        public ClienteController(DatabaseContext databaseContext)
        {
            clientes = GerarClientesMocados();
            representantes = GerarRepresentantesMocados();
            _databaseContext = databaseContext;
        }

        private IList<RepresentanteModel>? GerarRepresentantesMocados()
        {
            throw new NotImplementedException();
        }

        public IActionResult Index()
        {
            return View(clientes);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ClienteModel clienteModel)
        {
            Console.WriteLine("Cliente cadastrado");

            TempData["mensagemSucesso"] = "Cliente cadastrado";


            return View(nameof(Index));
        }




        private static List<ClienteModel> GerarClientesMocados()
        {
            var list = new List<ClienteModel>();

            for (int i = 1; i <= 5; i++)
            {
                var cliente = new ClienteModel
                {
                    ClienteId = i,
                    Nome = $"Cliente {i}",
                    Sobrenome = $"Sobrenome {i}",
                    Email = $"cliente{i}@email.com",
                    DataNascimento = DateTime.Now.AddYears(-30),
                    Observacao = $"Observação do cliente {i}",
                    Representante = new RepresentanteModel
                    {
                        RepresentanteId = i,
                        NomeRepresentante = $"Representante {i}",
                        Cpf = $"0000000000{i}"
                    }
                };

                list.Add(cliente);
            }

            return list;
        }
    }
}
