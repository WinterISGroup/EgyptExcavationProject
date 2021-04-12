using EgyptExcavationProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

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
            if (gender == null)
                return list;
            else
            {
                list = list.Where(b => b.GenderGe == gender).ToList();
                return list;
            }
        }

        public List<Burial> FilterHairColor(List<Burial> list, string color)
        {
            list = list.Where(b => b.HairColor != null).ToList();

            return list.Where(b => b.HairColor.ToLower().Contains(color)).ToList();
        }

        //Age is first filter.Starts the initial filter from the context
        //Need to somehow filter the age from the string data
        //public IEnumerable<Burial> FilterAge(IEnumerable<Burial> list, string age)
        //{
        //    if (age == "0-10")
        //    {
        //        return list.Where(b => b.EstimateAge > 0 && b.EstimateAge <= 10);
        //    }
        //    else if (age == "11-20")
        //    {
        //        return list.Where(b => b.EstimateAge > 10 && b.EstimateAge <= 20);
        //    }
        //    else if (age == "21-30")
        //    {
        //        return list.Where(b => b.EstimateAge > 20 && b.EstimateAge <= 30);
        //    }
        //    else if (age == "31-40")
        //    {
        //        return list.Where(b => b.EstimateAge > 30 && b.EstimateAge <= 40);
        //    }
        //    else if (age == "41-50")
        //    {
        //        return list.Where(b => b.EstimateAge > 40 && b.EstimateAge <= 50);
        //    }
        //    else if (age == "51-60")
        //    {
        //        return list.Where(b => b.EstimateAge > 50 && b.EstimateAge <= 60);
        //    }
        //    else if (age == "61-70")
        //    {
        //        return list.Where(b => b.EstimateAge > 60 && b.EstimateAge <= 70);
        //    }
        //    else
        //    {
        //        return list;
        //    }
        //}

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
            else if (height == "1.6-2.0")
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
            else if (depth == "1.6-2.0")
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

            return list;
        }

        public List<Burial> FilterFoundYear(List<Burial> list, int? year)
        {
            var notNullList = (list.Where(b => b.DateFound != null)).ToList();

            return (notNullList.Where(b => b.DateFound.Value.Year == year)).ToList(); //.Year should automatically pull the year from the datetime?
        }

        public List<Burial> FilterFoundMonth(List<Burial> list, int? month)
        {
            var notNullList = (list.Where(b => b.DateFound != null)).ToList();

            return (notNullList.Where(b => b.DateFound.Value.Month == month)).ToList();
        }

        public List<Burial> FilterItemFound(List<Burial> list, string? item)
        {
            //List<Burial> listFilter = list.Where(b => b.ArtifactsDescription != null).ToList();

            List<Burial> listFilter = list.Where(b => b.ArtifactsDescription.ToLower().Contains(item)).ToList();

            return listFilter;
        }

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

        public List<Burial> FilterTextile(List<Burial> list, bool? textile)
        {
            return list.Where(b => b.TextileTaken == textile).ToList();
        }

        //Will it need to reference the locations table?
        //public List<Burial> FilterSquare(List<Burial> list, char? NS, int? NSlow, char? EW, int? EWlow)
        //{
        //    return list.Where(b => b.Location.LocationNs == NS && b.Location.LowPairNs == NSlow &&
        //                           b.Location.LocationEw == EW && b.Location.LowPairEw == EWlow).ToList();
        //}

        //Reference to locations table
        public List<Burial> FilterArea(List<Burial> list, string area)
        {
            List<Location> loc = _context.Location.Where(l => l.BurialSubplot == area).ToList();
            List<Guid> loc2 = _context.Location.Select(l => l.LocationId).ToList();

            List<Guid> stuff = new List<Guid>();

            foreach(Location l in loc)
            {
                stuff = loc2.Where(x => x == l.LocationId).ToList();
            }

            foreach(Guid g in stuff)
            {
                list.Where(b => b.LocationId == g).ToList();
            }

            return list;
        }

        public List<Burial> FilterHeadDirection(List<Burial> list, string direction)
        {
            return list.Where(b => b.HeadDirection == direction).ToList();
        }

        //Uses carbon dating analyses.May need to loop if multiple biosamples or
        //public List<Burial> FilterTimeOfBurial(List<Burial> list, string burial)
        //{
        //    List<Burial> listFilter = new List<Burial>();

        //    if (burial == "850-450")
        //    {
        //        listFilter = list.Where(b => Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) >= -850 &&
        //            Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) <= -450).ToList();
        //    }
        //    else if (burial == "449-200")
        //    {
        //        listFilter = list.Where(b => Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) >= -449 &&
        //            Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) <= -200).ToList();
        //    }
        //    else if (burial == "199-0")
        //    {
        //        listFilter = list.Where(b => Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) >= -199 &&
        //            Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) <= 0).ToList();
        //    }
        //    else if (burial == "1-200")
        //    {
        //        listFilter = list.Where(b => Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) >= 1 &&
        //            Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) <= 200).ToList();
        //    }
        //    else if (burial == "201-450")
        //    {
        //        listFilter = list.Where(b => Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) >= 201 &&
        //            Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) <= 450).ToList();
        //    }
        //    else if (burial == "451-850")
        //    {
        //        listFilter = list.Where(b => Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) >= 451 &&
        //            Int32.Parse(b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate) <= 850).ToList();
        //    }
        //    else
        //    {
        //        return list;
        //    }
        //    return listFilter;
        //}

        //Main function to utilize all the individual functions.Will be called in controller
        public List<Burial> FilterAllData(IFormCollection form)
        {
            List<Burial> results = _context.Burial.ToList();

            results = FilterGender(results, form["gender-filter"]);

            if (form["hair-filter"] != "")
            {
                results = FilterHairColor(results, form["hair-filter"]);
            }
            //if (form["age-filter"] != "")
            //{
            //    results = FilterAge(results, form["age-filter"]);
            //}
            if (form["height-filter"] != "")
            {
                results = FilterHeight(results, form["heigh-filter"]);
            }
            if (form["burial-depth-filter"] != "")
            {
                results = FilterBurialDepth(results, form["burial-depth-filter"]);
            }
            if (Int32.Parse(form["date-found-year-filter"].ToString()) != 0)
            {
                results = FilterFoundYear(results, Int32.Parse(form["date-found-year-filter"].ToString()));
            }
            if (Int32.Parse(form["date-found-month-filter"].ToString()) != 0)
            {
                results = FilterFoundMonth(results, Int32.Parse(form["date-found-month-filter"].ToString()));
            }
            if (form["item-found-filter"].ToString() != "")
            {
                results = FilterItemFound(results, form["item-found-filter"]);
            }
            if (form["remain-length-filter"] != "")
            {
                results = FilterRemainLength(results, form["remain-length-filter"]);
            }
            if (form["textile-taken-filter"].ToString() != "")
            {
                results = FilterTextile(results, Boolean.Parse(form["textile-taken-filter"].ToString()));
            }
            //if (form["NS-square-filter"].ToString() != null && form["low-pair-NS-filter"].ToString() != null && form["EW-square-filter"].ToString() != null && form["low-pair-EW-filter"].ToString() != null)
            //{
            //    results = FilterSquare(results, Convert.ToChar(form["NS-square-filter"]), Int32.Parse(form["low-pair-NS-filter"].ToString()), Convert.ToChar(form["EW-square-filter"]), Int32.Parse(form["low-pair-EW-filter"].ToString()));
            //}
            if (form["area-filter"].ToString() != "")
            {
                results = FilterArea(results, form["area-filter"]);
            }
            if (form["head-dir-filter"].ToString() != "")
            {
                results = FilterHeadDirection(results, form["head-dir-filter"]);
            }
            //if (form["burial-time-filter"].ToString() != "")
            //{
            //    results = FilterTimeOfBurial(results, form["burial-time-filter"]);
            //}

            return results;
        }
    }
}
