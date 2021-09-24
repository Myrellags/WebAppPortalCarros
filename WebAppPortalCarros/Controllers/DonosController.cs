using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.WebPages.Html;
using WebAppPortalCarros.Data;
using WebAppPortalCarros.Models;
using WebAppPortalCarros.Models.ViewModel;

namespace WebAppPortalCarros.Controllers
{
    public class DonoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonoController(ApplicationDbContext context)
        {
            _context = context;
        }

        string Baseurl = "https://localhost:44325/";
        public IActionResult Create()
        {
            ViewBag.Paises = _context.Paises;
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (var labels in _context.Distritos)
            {
                item.Add(new SelectListItem { Text = labels.NomeDistrito, Value = labels.DistritoID.ToString() });
            }
            ViewBag.Distritos = item;
            var model = new DonoViewModel();
            return View(model);
        }

        public async Task<IActionResult> Index()
        {

            List<Dono> DonoInfo = new List<Dono>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Donos/GetDono");
                if (Res.IsSuccessStatusCode)
                {
                    var DonoResponse = Res.Content.ReadAsStringAsync().Result;
                    DonoInfo = JsonConvert.DeserializeObject<List<Dono>>(DonoResponse);
                }
                return View(DonoInfo);
            }
        }

        [HttpPost]
        public ActionResult Create(DonoViewModel model)
        {

            var dono = new Dono();
            var email = new Email();
            var morada = new Morada();
            var contacto = new Contacto();

            dono.Nome = model.Dono.Nome;
            dono.NIF = model.Dono.NIF;
            email.EmailDono = model.Email.EmailDono;
            morada.Rua = model.Morada.Rua;
            morada.DistritoID = model.Morada.DistritoID;
            morada.Numero = model.Morada.Numero;
            morada.CodigoPostal = model.Morada.CodigoPostal;
            contacto.SufixoContacto = model.Contacto.SufixoContacto;
            contacto.NumeroContacto = model.Contacto.NumeroContacto;

            if (ModelState.IsValid)
            {
                //carro.Imagem = nomeCompleto;
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri(Baseurl);
                    var postDono = cliente.PostAsJsonAsync<Dono>("api/Donos/PostDono", dono);
                    postDono.Wait();

                    //var idDono = (from id in _context.Donos select new { id.DonoID }).Take(1).Max(evento => evento.DonoID);
                    var idDono = (from id in _context.Donos select new { id.DonoID }).Max(evento => evento.DonoID);
                    email.DonoID = idDono;
                    morada.DonoID = idDono;
                    contacto.DonoID = idDono;

                    var postMorada = cliente.PostAsJsonAsync<Morada>("api/Donos/PostMorada", morada);
                    postMorada.Wait();
                    var postEmail = cliente.PostAsJsonAsync<Email>("api/Donos/PostEmail", email);
                    postEmail.Wait();
                    var postContacto = cliente.PostAsJsonAsync<Contacto>("api/Donos/PostContacto", contacto);
                    postContacto.Wait();

                    var result = postDono.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DonoViewModel model)
        {

            Dono dono = null;
            dono.Deletado = true;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP PUT
                var putTask = client.PutAsJsonAsync<Dono>("api/Donos/DeleteDono/", dono);
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
        public ActionResult Details(int? id)
        {
            
            var img = _context.Imagens.FirstOrDefault(m => m.DonoID == id);
            if (img != null)
            {
                string imageBase64Data = Convert.ToBase64String(img.Image);
                string imageDataURL = string.Format("data:image/jpg;base64,{0}", imageBase64Data);
                ViewBag.ImageDataUrl = imageDataURL;
            }

            ViewBag.Distritos = _context.Distritos;
            DonoViewModel dono = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                //HTTP GET
                var responseTask = client.GetAsync($"api/Donos/GetDonoId/{id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DonoViewModel>();
                    readTask.Wait();
                    dono = readTask.Result;
                }
            }
            return View(dono);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            List<SelectListItem> item = new List<SelectListItem>();
            foreach (var labels in _context.Distritos)
            {
                item.Add(new SelectListItem { Text = labels.NomeDistrito, Value = labels.DistritoID.ToString() });
            }
            ViewBag.Distritos = item;
            DonoViewModel donoViewModel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                //HTTP GET
                var responseTask = client.GetAsync($"api/Donos/GetDonoId/{id}");
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<DonoViewModel>();
                    readTask.Wait();
                    donoViewModel = readTask.Result;
                }
            }
            return View(donoViewModel);
        }

        [HttpPost]
        public ActionResult Edit(DonoViewModel model)
        {
            var email = model.Email;
            var morada = model.Morada;
            var contacto = model.Contacto;

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(Baseurl);
                //HTTP PUT
                var putDono = cliente.PutAsJsonAsync<DonoViewModel>("api/Donos/PutDono", model);
                putDono.Wait();
                var putMorada = cliente.PostAsJsonAsync<Morada>("api/Donos/PutMorada", morada);
                putMorada.Wait();
                var putEmail = cliente.PostAsJsonAsync<Email>("api/Donos/PutEmail", email);
                putEmail.Wait();
                var putContacto = cliente.PostAsJsonAsync<Contacto>("api/Donos/PutContacto", contacto);
                putContacto.Wait();

                var result = putDono.Result;

                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Index");
        }
    }
}
