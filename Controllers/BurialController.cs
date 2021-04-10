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
            return View(_recordService.GetAllBurials());
        }

        [HttpPost]
        public IActionResult BurialRecords(FormCollection form)
        {
            string hairFilterSelected = form["hair-filter"];
            return View();
        }

        public IActionResult ViewRecord(Guid burialID)
        {
            return View(_recordService.GetRecord(burialID));
        }

        [HttpGet]
        public IActionResult AddRecord()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRecord(Burial burial)
        {
            if (ModelState.IsValid)
            {
                //_recordService.AddLocation(newRecord.Location);
                //newRecord.Burial.Location = newRecord.Location;
                _recordService.AddBurial(burial);
                return RedirectToAction("ViewRecord", new { burialID = burial.BurialId });
            }
            else
            {
                return View(burial);
            }
            
        }

        public IActionResult EditRecord(Guid burialID)
        {
            Burial burial = _recordService.GetRecord(burialID);
            return View(burial);
        }

        [HttpPost]
        public IActionResult EditRecord(Burial burial)
        {
            if (ModelState.IsValid)
            {
                _recordService.UpdateRecord(burial);
                return RedirectToAction("ViewRecord", new { burialID = burial.BurialId });
            }
            else
            {
                return View(burial);
            }
        }

        public IActionResult DeleteRecord(Guid burialID)
        {
            _recordService.DeleteLocation(_recordService.GetRecord(burialID).LocationId.Value);
            _recordService.DeleteRecord(burialID);
            return RedirectToAction("BurialRecords");
        }
    }
}
