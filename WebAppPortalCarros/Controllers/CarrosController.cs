using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebAppPortalCarros.Data;
using WebAppPortalCarros.Models;
using WebAppPortalCarros.Models.ViewModel;

namespace WebAppPortalCarros.Controllers
{
    public class CarroController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarroController(ApplicationDbContext context)
        {
            _context = context;
        }

        string Baseurl = "https://localhost:44325/";
        public async Task<IActionResult> Index()
        {

            List<Carro> CarroInfo = new List<Carro>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Carros/GetCarro");
                if (Res.IsSuccessStatusCode)
                {
                    var CarResponse = Res.Content.ReadAsStringAsync().Result;
                    CarroInfo = JsonConvert.DeserializeObject<List<Carro>>(CarResponse);
                }
                return View(CarroInfo);
            }
        }

        public IActionResult Create()
        {
            ViewBag.Cores = _context.Cores;
            ViewBag.Combustiveis = _context.Combustiveis;
            ViewBag.Donos = _context.Donos;
            ViewBag.Marcas = _context.Marcas;
            ViewBag.Modelos = _context.Modelos;
            var model = new CarroViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(CarroViewModel model)
        {
            var carro = new Carro();
            var imageTypes = new string[]{
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/png"
                };
            if (model.ImageUpload == null || model.ImageUpload.Length == 0)
            {
                ModelState.AddModelError("Imagem", "Este campo é obrigatório");
            }
            else if (!imageTypes.Contains(model.ImageUpload.ContentType))
            {
                ModelState.AddModelError("Imagem", "Escolha uma imagem GIF, JPG ou PNG.");
            }
            string nomeArquivo = System.IO.Path.GetFileName(model.ImageUpload.FileName);
            string caminho = MyServer.MapPath("wwwroot/img");
            string nomeCompleto = System.IO.Path.Combine(caminho, nomeArquivo);
            if (model.ImageUpload != null)
            {
                //verifica se existe o diretório, caso não, cria
                if (System.IO.Directory.Exists(caminho) == false)
                    System.IO.Directory.CreateDirectory(caminho);
                //grava a imagem ou o arquivo
                model.ImageUpload.CopyTo(new FileStream(nomeCompleto, FileMode.Create));
            }

            if (ModelState.IsValid)
            {
                carro.Matricula = model.Carro.Matricula;
                carro.Ano = model.Carro.Ano;
                carro.Mes = model.Carro.Mes;
                carro.DonoID = model.Carro.DonoID;
                carro.CorID = model.Carro.CorID;
                carro.CombustivelID = model.Carro.CombustivelID;
                carro.Imagem = nomeCompleto;
            }

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(Baseurl);
                var postCar = cliente.PostAsJsonAsync<Carro>("api/Carros/PostCarro", carro);
                postCar.Wait();

                var result = postCar.Result;
                if(result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(model);
        }

        public async Task<IActionResult> Details()
        {
            List<Carro> CarDetails = new List<Carro>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Carro/GetCarroId");
                if (Res.IsSuccessStatusCode)
                {
                    var record = Res.Content.ReadAsStringAsync().Result;
                    CarDetails = JsonConvert.DeserializeObject<List<Carro>>(record);
                }
                return View(CarDetails);
            }
        }

    }
}
