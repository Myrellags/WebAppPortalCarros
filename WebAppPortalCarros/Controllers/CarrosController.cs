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
            var img = new Imagem();
            var carro = new Carro();
            foreach (var file in Request.Form.Files)
            {
                MemoryStream ms = new MemoryStream();
                file.CopyTo(ms);
                img.Image = ms.ToArray();

                ms.Close();
                ms.Dispose();
            }
            
            carro.Matricula = model.Matricula;
           // carro.Ano = anoCarro.FirstOrDefault();
            carro.Mes = model.Mes;
            carro.DonoID = model.DonoID;
            carro.CorID = model.CorID;
            carro.CombustivelID = model.CombustivelID;
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

                    var idCarro = (from id in _context.Carros select new { id.CarroID }).Max(evento => evento.CarroID);
                    img.CarroID = idCarro;

                    var postImagem = cliente.PostAsJsonAsync<Imagem>("api/Carros/PostImagem", img);
                    postImagem.Wait();

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

        //public async Task<IActionResult> Details()
        //{
        //    List<Carro> CarDetails = new List<Carro>();
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        HttpResponseMessage Res = await client.GetAsync("api/Carro/GetCarroId");
        //        if (Res.IsSuccessStatusCode)
        //        {
        //            var record = Res.Content.ReadAsStringAsync().Result;
        //            CarDetails = JsonConvert.DeserializeObject<List<Carro>>(record);
        //        }
        //        return View(CarDetails);
        //    }
        //}

        [HttpGet]
        public ActionResult Details(int? id)
        {
            //var img = _context.Imagens.OrderByDescending(i => i.ImagemID).SingleOrDefault();
            //var img = _context.Imagens.FirstOrDefault(m => m.CarroID == id);

            var img = _context.Imagens.FirstOrDefault(m => m.CarroID == id);
            if (img!= null)
            {
                string imageBase64Data = Convert.ToBase64String(img.Image);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }
            
            //Fazer isto na API e carregar aqui(FUTURO) - ORGANIZAR CÓDIGO -------------------------
            

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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
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

