using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using WebAppPortalCarros.Data;
using WebAppPortalCarros.Models;

namespace WebAppPortalCarros.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Cores = _context.Cores.GroupBy(c => c.NomeCor).ToList(); ;
            ViewBag.Quantidade = _context.Carros.GroupBy(c => c.Cor.NomeCor).Count();
            return View();
        }

        //public JsonResult Listar()
        //{
        //    var listaCores = _context.Carros.GroupBy(c => c.Cor.NomeCor).Count();

        //    return new JsonResult(new { data = listaCores });
        //}

        //public ActionResult getGrafico()
        //{
        //    ViewBag.Cores = _context.Cores.GroupBy(c => c.NomeCor).ToList(); ;
        //    ViewBag.Quantidade = _context.Carros.GroupBy(c => c.Cor.NomeCor).Count();
        //    return View();
        //    //for (var cor = 1; cor <= )

        //    //var query = _context.Carros.GroupBy(c => c.Cor.NomeCor).Count();
        //    //List<CarrosTopCores> listaCores = null;
        //    //listaCores = new List<CarrosTopCores>();
        //    ////varre a lista
        //    //foreach()
        //    //{
        //    //    CarrosTopCores carrosTopCores = new CarrosTopCores();
        //    //    carrosTopCores.CorName = query.ToString();
        //    //    //carrosTopCores.Quantidade = query
        //    //    listaCores.Add(carrosTopCores);
        //    //}


        //    //var myChart = new Chart(width: 600, height: 400, theme: ChartTheme.Yellow)
        //    // .AddTitle("As 5 cores mais vendidas")
        //    // .DataBindTable(dataSource: listaCores, xField: "CorName")
        //    // .Write();
        //    //return null;
        //}

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
