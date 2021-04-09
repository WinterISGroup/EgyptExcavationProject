using EgyptExcavationProject.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Controllers
{
    public class BurialController : Controller
    {
        private IRecordService _recordService;
        private IFilterService _filterService;
        public BurialController(IRecordService recordService, IFilterService filterService)
        {
            _recordService = recordService;
            _filterService = filterService;
        }
        public IActionResult BurialRecords()
        {
            return View();
        }

        public IActionResult ViewRecord(int id)
        {
            return View();
        }

        public IActionResult AddRecord()
        {
            _recordService.AddRecord("hello");
            return View();
        }

        public IActionResult EditRecord()
        {
            return View();
        }

        public IActionResult DeleteRecord()
        {
            return RedirectToAction("BurialRecords");
        }
    }
}
