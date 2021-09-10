using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPortalCarros.Controllers
{
    public class DonoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
