using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Week44Exercises.Models;

namespace Week44Exercises.Controllers
{
    public class DataController : Controller
    {
        const string DataKey = "_Data";

        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Input(DataModel dataModel)
        {
            HttpContext.Session.Set<DataModel>(DataKey, dataModel);

            return View();
        }

        public IActionResult Output()
        {
            DataModel data = HttpContext.Session.Get<DataModel>(DataKey);
            ViewData["data"] = data;
            
            return View();
        }
    }
}
