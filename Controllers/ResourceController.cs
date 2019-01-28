using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using GU.Class;
using GU.Data;
using GU.Models;

namespace GU.Controllers
{
    public class ResourceController : Controller
    {
        private readonly GU_DB _context;
        private ClassResource _CLSR;

        public ResourceController(GU_DB context, IConfiguration configuration)
        {
            _context = context;

            _CLSR = new ClassResource(context, configuration);
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}