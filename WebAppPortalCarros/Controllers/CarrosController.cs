using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public ActionResult Grafico()
        {
            ViewBag.Cores = (from p in _context.Cores group p by p.NomeCor into g select new { g.Key }).ToList();
            return View();
        }

        public async Task<IActionResult> Index()
        {

            var result = (from Cores in _context.Cores
                          join Carros in _context.Carros on Cores.CorID equals Carros.CorID
                          group Cores by Cores.NomeCor into count

                          select new
                          {
                              Cores = count.Key,
                              Sum = count.Select(i => i.CorID).Count()

                          }).ToList();

            ViewBag.Cores = result.Select(x => x.Cores).ToArray();
            ViewBag.Quantidade = result.Select(x => x.Sum).ToArray();

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
            ViewBag.Anos = _context.Anos;
            var model = new CarroViewModel();
            return View(model);
        }


        [HttpPost]
        public ActionResult Create(CarroViewModel model)
        {

            //var imageTypes = new string[]{
            //        "image/gif",
            //        "image/jpeg",
            //        "image/pjpeg",
            //        "image/png"
            //    };
            //if (model.ImageUpload == null || model.ImageUpload.Length == 0)
            //{
            //    ModelState.AddModelError("Imagem", "Este campo é obrigatório");
            //}
            //else if (!imageTypes.Contains(model.ImageUpload.ContentType))
            //{
            //    ModelState.AddModelError("Imagem", "Escolha uma imagem GIF, JPG ou PNG.");
            //}
            //string nomeArquivo = System.IO.Path.GetFileName(model.ImageUpload.FileName);
            //string caminho = MyServer.MapPath("wwwroot/img/cadastros");
            //string nomeCompleto = System.IO.Path.Combine(caminho, nomeArquivo);
            //if (model.ImageUpload != null)
            //{
            //    //verifica se existe o diretório, caso não, cria
            //    if (System.IO.Directory.Exists(caminho) == false)
            //        System.IO.Directory.CreateDirectory(caminho);
            //    //grava a imagem ou o arquivo
            //    model.ImageUpload.CopyTo(new FileStream(nomeCompleto, FileMode.Create));
            //}

            //var carro = model.Carro;
            //var anoCarro = from ano in _context.Anos
            //           where ano.AnoID == model.AnoID
            //           select ano.AnoValor;
            //var marcaCarro = from marca in _context.Marcas
            //               where marca.MarcaID == model.MarcaID
            //               select marca.NomeMarca;
            var carro = new Carro();
            carro.Matricula = model.Matricula;
           // carro.Ano = anoCarro.FirstOrDefault();
            carro.Mes = model.Mes;
            carro.DonoID = model.DonoID;
            carro.CorID = model.CorID;
            carro.CombustivelID = model.CombustivelID;
           // carro.Marca = marcaCarro.FirstOrDefault();
            carro.ModeloID = model.ModeloID;
            if (ModelState.IsValid)
            {
                //carro.Imagem = nomeCompleto;
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(Baseurl);
                    var postCar = cliente.PostAsJsonAsync<Carro>("api/Carros/PostCarro", carro);
                    postCar.Wait();

                    var result = postCar.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ViewBag.Cores = _context.Cores;
            ViewBag.Combustiveis = _context.Combustiveis;
            ViewBag.Donos = _context.Donos;
            ViewBag.Marcas = _context.Marcas;
            ViewBag.Modelos = _context.Modelos;
            ViewBag.Anos = _context.Anos;
            CarroViewModel carro = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP GET
                var responseTask = client.GetAsync($"api/Carros/GetCarroId/{id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CarroViewModel>();
                    readTask.Wait();
                    carro = readTask.Result;
                }
            }
            return View(carro);
        }

        [HttpPost]
        public ActionResult Edit(CarroViewModel model)
        {
            //if (contato == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            var carro = model;
            carro.Matricula = model.Matricula;
            // carro.Ano = anoCarro.FirstOrDefault();
            carro.Mes = model.Mes;
            carro.DonoID = model.DonoID;
            carro.CorID = model.CorID;
            carro.CombustivelID = model.CombustivelID;
            // carro.Marca = marcaCarro.FirstOrDefault();
            carro.ModeloID = model.ModeloID;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<CarroViewModel>("api/Carros/PutCarro/", carro);
                putTask.Wait();
                var result = putTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            CarroViewModel carro = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP DELETE
                var deleteTask = client.DeleteAsync("api/Carros/DeleteCarro/" + id.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(carro);
        }
         
    }
}

