using EgyptExcavationProject.Infrastructure;
using EgyptExcavationProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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

            //if (age == "0-10")
            //{
            //    listFilter = list.Where(b => Int32.Parse(b.EstimateAge) > 0 && Int32.Parse(b.EstimateAge) <= 10).ToList();
            //}
            //else if (age == "11-20")
            //{
            //    listFilter = list.Where(b => Int32.Parse(b.EstimateAge) > 10 && Int32.Parse(b.EstimateAge) <= 20).ToList();
            //}
            //else if (age == "21-30")
            //{
            //    listFilter = list.Where(b => Int32.Parse(b.EstimateAge) > 20 && Int32.Parse(b.EstimateAge) <= 30).ToList();
            //}
            //else if (age == "31-40")
            //{
            //    listFilter = list.Where(b => Int32.Parse(b.EstimateAge) > 30 && Int32.Parse(b.EstimateAge) <= 40).ToList();
            //}
            //else if (age == "41-50")
            //{
            //    listFilter = list.Where(b => Int32.Parse(b.EstimateAge) > 40 && Int32.Parse(b.EstimateAge) <= 50).ToList();
            //}
            //else if (age == "51-60")
            //{
            //    listFilter = list.Where(b => Int32.Parse(b.EstimateAge) > 50 && Int32.Parse(b.EstimateAge) <= 60).ToList();
            //}
            //else if (age == "61-70")
            //{
            //    listFilter = list.Where(b => Int32.Parse(b.EstimateAge) > 60 && Int32.Parse(b.EstimateAge) <= 70).ToList();
            //}
            //else
            //{
            //    return list;
            //}

            return listFilter;
        }

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
        public List<Burial> FilterSquare(List<Burial> list, char? NS, int? NSlow, char? EW, int? EWlow)
        {
            List<Guid> loc2 = _context.Location.Where(b => b.LocationNs == NS && b.LowPairNs == NSlow &&
            b.LocationEw == EW && b.LowPairEw == EWlow).Select(l => l.LocationId).ToList();

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

        //Main function to utilize all the individual functions.Will be called in controller
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
            if (data.TextileFound.ToString() != "")
            {
                results = FilterTextile(results, data.TextileFound);
            }
            if (data.SquareNS.ToString() != "" && data.NSLowPair.ToString() != "" && data.SquareEW.ToString() != "" && data.EWLowPair.ToString() != "")
            {
                results = FilterSquare(results, data.SquareNS, data.NSLowPair, data.SquareEW, data.EWLowPair);
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
    }
}
