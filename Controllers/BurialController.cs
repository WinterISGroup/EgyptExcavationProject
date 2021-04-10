using EgyptExcavationProject.Models;
using EgyptExcavationProject.Models.ViewModels;
using EgyptExcavationProject.Services;
using Microsoft.AspNetCore.Http;
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

        public IActionResult ViewRecord(Guid burialID)
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecord(AddRecordModel newRecord)
        {
            return View(newRecord);
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
