using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GU.Models;
using GU.Data;
using Microsoft.Extensions.Configuration;
using GU.Class;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace GU.Controllers
{
    public class AdminController : Controller
    {
        private readonly GU_DB _context;
        private ClassResource _CLSR;
        private IConfiguration _iconfiguration;
        private readonly String _Module = "Home";

        public AdminController(GU_DB context, IConfiguration configuration)
        {
            _context = context;
            _iconfiguration = configuration;
            _CLSR = new ClassResource(_context, configuration);

        }

        //SET SESSION (KEY,Value)
        //HttpContext.Session.SetString("userid", user.userid.ToString());




        public IActionResult Index()
        {
            return View();

        }

        [HttpGet]
        public IActionResult Create_Tree()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Create_Tree(string tree_name)
        {
            return View();

        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
