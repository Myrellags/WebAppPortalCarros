using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
            ViewBag.Distritos = _context.Distritos;
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
    }
}
