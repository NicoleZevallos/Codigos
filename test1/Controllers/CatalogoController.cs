using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using test1.Models;
using test1.Data;

namespace test1.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly ILogger<CatalogoController> _logger;
        private readonly ApplicationDbContext _dbcontext;


        public CatalogoController(ILogger<CatalogoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            var productos = from o in _dbcontext.DataProductos select o;
            
            return View(productos.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}