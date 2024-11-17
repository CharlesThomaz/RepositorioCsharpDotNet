using System.Diagnostics;
using br.com.devset.Data;
using br.com.devset.Models;
using Microsoft.AspNetCore.Mvc;
using br.com.devset.Logging;

namespace br.com.devset.Controllers
{
    public class HomeController : Controller
    {

        private readonly DatabaseContext _databaseContext;

        private readonly ICustomLogger _customlogger;   

        public HomeController(ICustomLogger customLogger)
        {
            _customlogger = customLogger;
        }
       

        public IActionResult Index()
        {
            _customlogger.Log("DEVSET");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
