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
        public IActionResult BurialRecords(int pageNum = 1)
        {
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

            if (TempData["isObjStored"] != null)
            {
                //listToView = _filterService.FilterAllData(TempData.Get<IFormCollection>("form"));
                PageNumInfo test = TempData.Get<PageNumInfo>("test");
                TempData.Keep("isObjStored");
                TempData.Keep("test");
            }
            else
            {
                listToView = _recordService.GetAllBurials().ToList();
            }
            listToView = _recordService.GetAllBurials().ToList();

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

            FilterData filterData = new FilterData();
            filterData.Gender = form["gender-filter"].ToString();
            filterData.HairColor = form["hair-filter"].ToString();
            filterData.AgeCode = form["age-filter"].ToString();
            filterData.Height = form["height-filter"].ToString();
            filterData.BurialDepth = form["burial-depth-filter"].ToString();
            filterData.LengthOfRemains = form["remain-length-filter"].ToString();
            filterData.DateFoundYear = Int32.Parse(form["date-found-year-filter"].ToString());
            filterData.DateFoundMonth = Int32.Parse(form["date-found-month-filter"].ToString());
            filterData.ItemFound = form["item-found-filter"].ToString();
            filterData.TextileFound = Boolean.Parse(form["textile-taken-filter"].ToString());
            filterData.BurialTime = form["burial-time-filter"].ToString();
            filterData.SquareNS = Convert.ToChar(form["NS-square-filter"].ToString());
            filterData.NSLowPair = Int32.Parse(form["low-pair-NS-filter"].ToString());
            filterData.SquareEW = Convert.ToChar(form["EW-square-filter"].ToString());
            filterData.EWLowPair = Int32.Parse(form["low-pair-EW-filter"].ToString());
            filterData.SubPlot = form["area-filter"].ToString();
            filterData.HeadDirection = form["head-dir-filter"].ToString();


            int pageSize = 12;

            List<Burial> returnList = new List<Burial>();
            returnList = _filterService.FilterAllData(form);

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

            TempData["isObjStored"] = "true";
            TempData.Put("test", test);

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
