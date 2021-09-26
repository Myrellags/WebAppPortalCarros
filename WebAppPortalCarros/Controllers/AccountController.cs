using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppPortalCarros.Models;

namespace WebAppPortalCarros.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login login)
        {
            //Verificar se o Email+Password são corretos...

            //devolver ao fetch um objeto json - porque o fetch está à espera de receber um resultado com json:
            var resultado = new /*class anónima*/
            {
                Mensagem = "Sucesso",
                Email = login.Email,
                Password = login.Password
            };
            return Json(resultado);
        }

    }
}
