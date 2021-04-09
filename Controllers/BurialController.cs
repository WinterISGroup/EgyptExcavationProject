using EgyptExcavationProject.Models;
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
        public IActionResult AddRecord(FormCollection form)
        {   
            Burial burial = new Burial();
            Location loc = new Location();

            burial.DateFound = form["date-found"].ToString() != null ? Convert.ToDateTime(form["date-found"].ToString()) : Convert.ToDateTime(null);
            string excavationRecorder = form["exca-recorder"].ToString() != "" ? form["exca-recorder"].ToString() : ""; //FIX ME: Add to model
            loc.LocationNs = form["location-ns"].ToString() != "" ? Convert.ToChar(form["location-ns"].ToString()) : 'z'; //FIX ME: 

            if (ModelState.IsValid)
            {
                //_recordService.AddRecord(burial);
                return RedirectToAction("ViewRecord", new { burialID = burial.BurialId });
            }
            else
            {
                return View(burial);
            }
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
