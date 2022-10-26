using System;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.UI.Site.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

