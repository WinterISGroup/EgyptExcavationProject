using EgyptExcavationProject.Data;
using EgyptExcavationProject.Infrastructure;
using EgyptExcavationProject.Models;
using EgyptExcavationProject.Models.ViewModels;
using EgyptExcavationProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
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

        public IActionResult BurialRecords(int pageNum = 1, bool isPagination = false)
        {
            ViewBag.FilterSubmitted = false;

            if (User.IsInRole("Admin"))
            {
                ViewBag.Admin = true;
            }
            if (User.IsInRole("Researcher"))
            {
                ViewBag.Researcher = true;
            }
            int pageSize = 12;

            List<Burial> listToView = new List<Burial>();

            if (TempData["isDataStored"] != null && isPagination == true)
            {
                FilterData filterData = TempData.Get<FilterData>("filterData");
                listToView = _filterService.FilterAllData(filterData);

                TempData.Keep("isDataStored");
                TempData.Keep("filterData");
                ViewBag.FilterSubmitted = true;
                ViewBag.FilterDisplay = _filterService.GetActiveFilterDisplay(filterData);
            }
            else
            {
                listToView = _recordService.GetAllBurials().ToList();
            }

            BurialViewModel bvm = new BurialViewModel
            {
                Burials = listToView.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList(),

                PageNumInfo = new PageNumInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = listToView.Count()
                }
            };

            

            return View(bvm);
        }

        [HttpPost]
        public IActionResult BurialRecords(IFormCollection form, int pageNum = 1)
        {
            if (User.IsInRole("Admin"))
            {
                ViewBag.Admin = true;
            }
            if (User.IsInRole("Researcher"))
            {
                ViewBag.Researcher = true;
            }

            FilterData filterData = _filterService.ParseFormData(form);

            int pageSize = 12;

            List<Burial> returnList = new List<Burial>();
            returnList = _filterService.FilterAllData(filterData);

            BurialViewModel bvm = new BurialViewModel
            {
                Burials = returnList.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList(),

                PageNumInfo = new PageNumInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,
                    TotalNumItems = returnList.Count()
                }
            };

            PageNumInfo test = new PageNumInfo
            {
                NumItemsPerPage = pageSize,
                CurrentPage = pageNum,
                TotalNumItems = returnList.Count()
            };

            TempData["isDataStored"] = "true";
            TempData.Put("filterData", filterData);

            ViewBag.FilterSubmitted = true;
            ViewBag.FilterDisplay = _filterService.GetActiveFilterDisplay(filterData);

            return View(bvm);
        }

        [HttpGet]
        public IActionResult ViewRecord(Guid burialID)
        {
            return View(_recordService.GetRecord(burialID));
        }

        [HttpPost]
        public async Task<IActionResult> ViewRecord(FileUploadFormModal FileUpload)
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {

                    string fileExtension = FileUpload.FormFile.FileName.Split(".")[1];

                    string randomId = Guid.NewGuid().ToString();

                    string fileName = randomId + "." + fileExtension;

                    await S3Upload.UploadFileAsync(memoryStream, "egyptexcavation", "photos/" + fileName);

                    string uploadUrl = "https://egyptexcavation.s3.amazonaws.com/photos/" + fileName;

                    _recordService.SavePhotoUrl(FileUpload.BurialID, uploadUrl);
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                    return View(FileUpload);
                }
            }

            return RedirectToAction("ViewRecord", new { burialID = FileUpload.BurialID });
            //return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin, Researcher")]
        public IActionResult AddRecord()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Researcher")]
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

        [HttpGet]
        [Authorize(Roles = "Admin, Researcher")]
        public IActionResult EditRecord(Guid burialID)
        {
            Burial burial = _recordService.GetRecord(burialID);
            return View(burial);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Researcher")]
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

        [Authorize(Roles = "Admin")]
        public IActionResult DeleteRecord(Guid burialID)
        {
            _recordService.DeleteLocation(_recordService.GetRecord(burialID).LocationId.Value);
            _recordService.DeleteRecord(burialID);
            return RedirectToAction("BurialRecords");
        }

        // File uploading
        public IActionResult FileUploadForm()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> FileUploadForm(FileUploadFormModal FileUpload)
        {
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                // Upload the file if less than 2 MB
                if (memoryStream.Length < 2097152)
                {

                    string fileExtension = FileUpload.FormFile.FileName.Split(".")[1];

                    string randomId = Guid.NewGuid().ToString();

                    string fileName = randomId + "." + fileExtension;

                    await S3Upload.UploadFileAsync(memoryStream, "egyptexcavation", "photos/" + fileName);

                    string uploadUrl = "https://egyptexcavation.s3.amazonaws.com/photos/" + fileName;

                    //_recordService.SavePhotoUrl(FileUpload.BurialID, uploadUrl);
                }
                else
                {
                    ModelState.AddModelError("File", "The file is too large.");
                    return View(FileUpload);
                }
            }

            //return RedirectToAction("ViewRecord", new { burialID = FileUpload.BurialID });
            return View();
        }
    }
}
