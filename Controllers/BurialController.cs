using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Controllers
{
    public class BurialController : Controller
    {
        public IActionResult BurialSummary()
        {
            return View();
        }

        public IActionResult BurialRecord()
        {
            return View();
        }

        public IActionResult AddRecord()
        {
            return View();
        }

        public IActionResult EditRecord()
        {
            return View();
        }

        public IActionResult DeleteRecord()
        {
            return View();
        }
    }
}
