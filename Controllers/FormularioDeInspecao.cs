using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VistoriaDeVeiculos.Controllers
{
    public class FormularioDeInspecao : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
