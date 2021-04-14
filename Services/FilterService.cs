using EgyptExcavationProject.Infrastructure;
using EgyptExcavationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

//This is a service to handle the heavy logic neccessary for filtering. This takes the bulk out of the controller and will run through multiple
//functions to query the data to be returned.
namespace EgyptExcavationProject.Services
{
    public class FilterService : IFilterService
    {

        private ExcavationProjectContext _context;
        public FilterService(ExcavationProjectContext context)
        {
            _context = context;
        }
        
        //Ask about the gender columns.
        public List<Burial> FilterGender(List<Burial> list, string gender)
        {
            if (gender == "")
                return list;
            else
            {
                list = list.Where(b => b.GenderGe == gender).ToList();
                return list;
            }
        }

        //Filters by hair color. Designed to search if string even contains the keyword
        public List<Burial> FilterHairColor(List<Burial> list, string color)
        {
            list = list.Where(b => b.HairColor != "").ToList();

            return list.Where(b => b.HairColor.ToLower().Contains(color)).ToList();
        }

        //Age is first filter.Starts the initial filter from the context
        //Need to somehow filter the age from the string data
        public List<Burial> FilterAge(List<Burial> list, string age)
        {
            List<Burial> listFilter = new List<Burial>();

            if(age == "C")
            {
                listFilter = list.Where(b => b.AgeCode == "C").ToList();
            }
            else if (age == "A")
            {
                listFilter = list.Where(b => b.AgeCode == "A").ToList();
            }
            else if (age == "N/I")
            {
                listFilter = list.Where(b => b.AgeCode == "N/I").ToList();
            }
            else if (age == "U")
            {
                listFilter = list.Where(b => b.AgeCode == "U").ToList();
            }
            else
            {
                return list;
            }

            return listFilter;
        }

        //Living stature. Searches a range of values (in meters).
        public List<Burial> FilterHeight(List<Burial> list, string height)
        {
            List<Burial> listFilter = new List<Burial>();

            if (height == "0-.5")
            {
                listFilter = (list.Where(b => b.EstimateLivingStature > 0 && b.EstimateLivingStature <= 0.59)).ToList();
            }
            else if (height == ".6-1")
            {
                listFilter = (list.Where(b => b.EstimateLivingStature > 0.59 && b.EstimateLivingStature <= 1.09)).ToList();
            }
            else if (height == "1.1-1.5")
            {
                listFilter = (list.Where(b => b.EstimateLivingStature > 1.09 && b.EstimateLivingStature <= 1.59)).ToList();
            }
            else if (height == "1.6-2")
            {
                listFilter = (list.Where(b => b.EstimateLivingStature > 1.59 && b.EstimateLivingStature <= 2.09)).ToList();
            }
            else if (height == "2.1-2.5")
            {
                listFilter = (list.Where(b => b.EstimateLivingStature > 2.09 && b.EstimateLivingStature <= 2.59)).ToList();
            }
            else if (height == "2.6-3")
            {
                listFilter = (list.Where(b => b.EstimateLivingStature > 2.59 && b.EstimateLivingStature <= 3.09)).ToList();
            }
            else
            {
                return list;
            }

            return listFilter;
        }

        //Depth of burial. Searches range of values (in meters).
        public List<Burial> FilterBurialDepth(List<Burial> list, string depth) 
        {
            List<Burial> listFilter = new List<Burial>();

            if (depth == "0-.5")
            {
                listFilter = (list.Where(b => b.BurialDepth > 0 && b.BurialDepth <= 0.59)).ToList();
            }
            else if (depth == ".6-1")
            {
                listFilter = (list.Where(b => b.BurialDepth > 0.59 && b.BurialDepth <= 1.09)).ToList();
            }
            else if (depth == "1.1-1.5")
            {
                listFilter = (list.Where(b => b.BurialDepth > 1.09 && b.BurialDepth <= 1.59)).ToList();
            }
            else if (depth == "1.6-2")
            {
                listFilter = (list.Where(b => b.BurialDepth > 1.59 && b.BurialDepth <= 2.09)).ToList();
            }
            else if (depth == "2.1-2.5")
            {
                listFilter = (list.Where(b => b.BurialDepth > 2.09 && b.BurialDepth <= 2.59)).ToList();
            }
            else if (depth == "2.6-3")
            {
                listFilter = (list.Where(b => b.BurialDepth > 2.59 && b.BurialDepth <= 3.09)).ToList();
            }
            else if (depth == "3.1-3.5")
            {
                listFilter = (list.Where(b => b.BurialDepth > 3.09 && b.BurialDepth <= 3.59)).ToList();
            }
            else if (depth == "3.6-4")
            {
                listFilter = (list.Where(b => b.BurialDepth > 3.59 && b.BurialDepth <= 4.09)).ToList();
            }
            else
            {
                return list;
            }

            return listFilter;
        }

        //Year found
        public List<Burial> FilterFoundYear(List<Burial> list, int? year)
        {
            var notNullList = (list.Where(b => b.DateFound != null)).ToList();

            return (notNullList.Where(b => b.DateFound.Value.Year == year)).ToList(); //.Year should automatically pull the year from the datetime?
        }

        //Month found 1-12
        public List<Burial> FilterFoundMonth(List<Burial> list, int? month)
        {
            var notNullList = (list.Where(b => b.DateFound != null)).ToList();

            return (notNullList.Where(b => b.DateFound.Value.Month == month)).ToList();
        }

        //Pulls from a list of common items found. Will search the artifacts description if it contains the string
        public List<Burial> FilterItemFound(List<Burial> list, string? item)
        {
            List<Burial> listFilter = list.Where(b => b.ArtifactsDescription != null).ToList();

            listFilter = listFilter.Where(b => b.ArtifactsDescription.ToLower().Contains(item)).ToList();

            return listFilter;
        }

        //The length of the remains laying in the ground
        public List<Burial> FilterRemainLength(List<Burial> list, string length)
        {
            List<Burial> listFilter = new List<Burial>();

            if (length == "0-1")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 0 && b.LengthOfRemains <= 1).ToList();
            }
            else if (length == "1-2")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 1.01 && b.LengthOfRemains <= 2).ToList();
            }
            else if (length == "2-3")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 2.01 && b.LengthOfRemains <= 3).ToList();
            }
            else if (length == "3-4")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 3.01 && b.LengthOfRemains <= 4).ToList();
            }
            else if (length == "4-5")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 4.01 && b.LengthOfRemains <= 5).ToList();
            }
            else if (length == "5-6")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 5.01 && b.LengthOfRemains <= 6).ToList();
            }
            else if (length == "6-7")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 6.01 && b.LengthOfRemains <= 7).ToList();
            }
            else if (length == "7-8")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 7.01 && b.LengthOfRemains <= 8).ToList();
            }
            else if (length == "8-9")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 8.01 && b.LengthOfRemains <= 9).ToList();
            }
            else if (length == "9-10")
            {
                listFilter = list.Where(b => b.LengthOfRemains > 9.01 && b.LengthOfRemains <= 10).ToList();
            }
            else
            {
                return list;
            }

            return listFilter;
        }

        //Boolean to see if textiles were found with burial
        public List<Burial> FilterTextile(List<Burial> list, string textile)
        {
            return list.Where(b => b.TextileTaken == Boolean.Parse(textile)).ToList();
        }

        //Filters the location block. Pulls data from location table through burials.
        public List<Burial> FilterSquare(List<Burial> list, char? NS, int? NSlow, char? EW, int? EWlow)
        {
            List<Guid> loc2 = _context.Location.Where(b => b.LocationNs == NS.Value && b.LowPairNs == NSlow.Value &&
            b.LocationEw == EW.Value && b.LowPairEw == EWlow.Value).Select(l => l.LocationId).ToList();

            List < Burial> results = new List<Burial>();

            foreach (var burial in list)
            {
                if (burial.LocationId != null)
                {
                    if (loc2.Contains(burial.LocationId.Value))
                    {
                        results.Add(burial);
                    }
                }
            }

            return (results);
        }

        //Reference to locations table
        public List<Burial> FilterArea(List<Burial> list, string area)
        {
            List<Guid> loc = _context.Location.Where(l => l.BurialSubplot == area).Select(l => l.LocationId).ToList();

            List<Burial> results = new List<Burial>();

            foreach (var burial in list)
            {
                if (burial.LocationId != null)
                {
                    if (loc.Contains(burial.LocationId.Value))
                    {
                        results.Add(burial);
                    }
                }
            }

            return (results);
        }

        //Head direction filter. East or West
        public List<Burial> FilterHeadDirection(List<Burial> list, string direction)
        {
            return list.Where(b => b.HeadDirection == direction).ToList();
        }

        //Uses carbon dating analyses.May need to loop if multiple biosamples or
        public List<Burial> FilterTimeOfBurial(List<Burial> list, string time)
        {
            List<Burial> listFilter = new List<Burial>();

            int upper = 0;
            int lower = 0;

            if (time == "850-450")
            {
                upper = -450;
                lower = -850;
            }
            else if (time == "449-200")
            {
                upper = -200;
                lower = -449;
            }
            else if (time == "199-0")
            {
                upper = 0;
                lower = -199;
            }
            else if (time == "1-200")
            {
                upper = 1;
                lower = 200;
            }
            else if (time == "201-450")
            {
                upper = 450;
                lower = 201;
            }
            else if (time == "451-850")
            {
                upper = 850;
                lower = 451;
            }
            else
            {
                return list;
            }

            List<CarbonDatingAnalysis> cd = _context.CarbonDatingAnalysis.Where(c => c.C14CalendarDate != "" && c.SampleId != null).ToList();

            List<Guid> ca = cd.Where(c => Int32.Parse(c.C14CalendarDate) >= upper && Int32.Parse(c.C14CalendarDate) <= lower).Select(s => s.SampleId.Value).ToList();

            List<Guid> burialIDs = new List<Guid>();

            foreach(BioSample b in _context.BioSample)
            {
                if(ca.Contains(b.SampleId))
                {
                    burialIDs.Add(b.BurialId.Value);
                }
            }

            foreach(Guid id in burialIDs)
            {
                listFilter.Add(list.Where(b => b.BurialId == id).FirstOrDefault());
            }

            return listFilter;
        }

        //Main function to utilize all the individual functions. Will be called in controller
        public List<Burial> FilterAllData(FilterData data)
        {
            List<Burial> results = _context.Burial.ToList();

            results = FilterGender(results, data.Gender);

            if (data.HairColor != "")
            {
                results = FilterHairColor(results, data.HairColor);
            }
            if (data.AgeCode != "")
            {
                results = FilterAge(results, data.AgeCode);
            }
            if (data.Height != "")
            {
                results = FilterHeight(results, data.Height);
            }
            if (data.BurialDepth != "")
            {
                results = FilterBurialDepth(results, data.BurialDepth);
            }
            if (data.DateFoundYear != 0)
            {
                results = FilterFoundYear(results, data.DateFoundYear);
            }
            if (data.DateFoundMonth != 0)
            {
                results = FilterFoundMonth(results, data.DateFoundMonth);
            }
            if (data.ItemFound != "")
            {
                results = FilterItemFound(results, data.ItemFound);
            }
            if (data.LengthOfRemains != "")
            {
                results = FilterRemainLength(results, data.LengthOfRemains);
            }
            if (data.TextileFound != "")
            {
                results = FilterTextile(results, data.TextileFound);
            }
            if (data.SquareNS != '\0' && data.NSLowPair != "" && data.SquareEW != '\0' && data.EWLowPair != "")
            {
                results = FilterSquare(results, data.SquareNS, Convert.ToInt32(data.NSLowPair), data.SquareEW, Convert.ToInt32(data.EWLowPair));
            }
            if (data.SubPlot != "")
            {
                results = FilterArea(results, data.SubPlot);
            }
            if (data.HeadDirection != "")
            {
                results = FilterHeadDirection(results, data.HeadDirection);
            }
            if (data.BurialTime != "")
            {
                results = FilterTimeOfBurial(results, data.BurialTime);
            }

            return results;
        }

        //Filter data object. This will assist in passing values to for pagination isntead of through
        public FilterData ParseFormData(IFormCollection form)
        {
            FilterData filterData = new FilterData();

            filterData.Gender = form["gender-filter"].ToString();
            filterData.HairColor = form["hair-filter"].ToString();
            filterData.AgeCode = form["age-filter"].ToString();
            filterData.Height = form["height-filter"].ToString();
            filterData.BurialDepth = form["burial-depth-filter"].ToString();
            filterData.LengthOfRemains = form["remain-length-filter"].ToString();
            filterData.DateFoundYear = form["date-found-year-filter"].ToString() != "" ? int.Parse(form["date-found-year-filter"].ToString()) : 0;
            filterData.DateFoundMonth = form["date-found-year-filter"].ToString() != "" ? int.Parse(form["date-found-month-filter"].ToString()) : 0;
            filterData.ItemFound = form["item-found-filter"].ToString();
            filterData.TextileFound = form["textile-taken-filter"].ToString();
            filterData.BurialTime = form["burial-time-filter"].ToString();
            filterData.SquareNS = form["NS-square-filter"].ToString() != "" ? Convert.ToChar(form["NS-square-filter"].ToString()) : '\0';
            filterData.NSLowPair = form["low-pair-NS-filter"].ToString() != "" ? form["low-pair-NS-filter"].ToString() : "";
            filterData.NSHighPair = form["high-pair-NS-filter"].ToString() != "" ? form["high-pair-NS-filter"].ToString() : "";
            filterData.SquareEW = form["EW-square-filter"].ToString() != "" ? Convert.ToChar(form["EW-square-filter"].ToString()) : '\0';
            filterData.EWLowPair = form["low-pair-EW-filter"].ToString() != "" ? form["low-pair-EW-filter"].ToString() : "";
            filterData.EWHighPair = form["high-pair-EW-filter"].ToString() != "" ? form["high-pair-EW-filter"].ToString() : "";
            filterData.SubPlot = form["area-filter"].ToString();
            filterData.HeadDirection = form["head-dir-filter"].ToString();

            return filterData;
        }

        //Data for the filters that are currently active for a query. Wil ldisplay the filters and their values for a search.
        public string GetActiveFilterDisplay(FilterData filterData)
        {
            string result = "<br/><span class='text-black-olive' style='font-size:12pt;'>";
            result += filterData.Gender != "" ? "Gender: <b>" + filterData.Gender + "</b>, " : "";
            result += filterData.HairColor != "" ? "Hair Color: <b>" + filterData.HairColor + "</b>, " : "";
            result += filterData.AgeCode != "" ? "Age Code: <b>" + filterData.AgeCode + "</b>, " : "";
            result += filterData.Height != "" ? "Height: <b>" + filterData.Height + "</b>, " : "";
            result += filterData.BurialDepth != "" ? "Burial Depth: <b>" + filterData.BurialDepth + "</b>, " : "";
            result += filterData.LengthOfRemains != "" ? "Length Of Remains: <b>" + filterData.LengthOfRemains + "</b>, " : "";
            result += filterData.DateFoundYear != 0 ? "Date Found-Year: <b>" + filterData.DateFoundYear.ToString() + "</b>, " : "";
            result += filterData.DateFoundMonth != 0 ? "Date Found-Month: <b>" + DateTimeFormatInfo.CurrentInfo.GetMonthName(filterData.DateFoundMonth.Value) + "</b>, " : "";
            result += filterData.ItemFound != "" ? "Item Found: <b>" + filterData.ItemFound + "</b>, " : "";
            result += filterData.TextileFound != "" ? "Textile Taken: <b>" + filterData.TextileFound + "</b>, " : "";
            result += filterData.BurialTime != "" ? "Burial Time: <b>" + filterData.BurialTime + "</b>, " : "";
            result += filterData.SquareNS != '\0' ? "Square NS: <b>" + filterData.SquareNS.ToString() + "</b>, " : "";
            result += filterData.NSLowPair != "" && filterData.NSHighPair != "" ? "NS Low/High Pair: <b>" + filterData.NSLowPair.ToString() + "/" + filterData.NSHighPair.ToString() + "</b>, " : "";
            
            result += filterData.SquareEW != '\0' ? "Square EW: <b>" + filterData.SquareEW.ToString() + "</b>, " : "";
            result += filterData.EWLowPair != "" && filterData.EWHighPair != "" ? "EW Low/High Pair: <b>" + filterData.EWLowPair + "/" + filterData.EWHighPair.ToString() + "</b>, " : "";
            result += filterData.SubPlot != "" ? "Area: <b>" + filterData.SubPlot + "</b>, " : "";
            result += filterData.HeadDirection != "" ? "Head Direction: <b>" + filterData.HeadDirection + "</b>, " : "";
            result = result.Substring(0, result.Length - 2);
            result += "</span>";
           

            return result;
        }
    }
}
