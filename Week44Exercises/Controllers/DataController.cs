using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Week44Exercises.Models;
using System.Threading;

namespace Week44Exercises.Controllers
{
    public class DataController : Controller
    {
        private object o = new object();
        const string DataKey = "_Data";

        [HttpGet]
        public IActionResult Input()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Input(DataModel dataModel)
        {
            //using Session
            HttpContext.Session.Set<DataModel>(DataKey, dataModel);

            //using Repository
            Monitor.Enter(o);
            DataRepository.Instance.Add(dataModel);
            Monitor.Exit(o);

            return View();
        }

        public IActionResult Output()
        {
            //using Session
            DataModel data = HttpContext.Session.Get<DataModel>(DataKey);

            //using Repository
            Monitor.Enter(o);
            List<DataModel> getData = DataRepository.Instance.Get();
            Monitor.Exit(o);

            ViewData["data"] = getData[0];
            
            return View();
        }
    }
}
