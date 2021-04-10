using EgyptExcavationProject.Models;
using System;
using System.Collections.Generic;
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
        

        //Age is first filter. Starts the initial filter from the context
        //public IEnumerable<Burial> FilterAge(string age)
        //{
        //    var results;

        //    if (age == "0-10")
        //    {
        //        results = _context.Burial.Where(b => b.EstimateAge > 0 && b.EstimateAge <= 10).ToEnumerable();
        //    }
        //    if else (age == "11-20")
        //    {
        //        results = _context.Burial.Where(b => b.EstimateAge > 10 && b.EstimateAge <= 20).ToEnumerable();
        //    }
        //    if else (age == "21-30")
        //    {
        //        results = _context.Burial.Where(b => b.EstimateAge > 20 && b.EstimateAge <= 30).ToEnumerable();
        //    }
        //    if else (age == "31-40")
        //    {
        //        results = _context.Burial.Where(b => b.EstimateAge > 30 && b.EstimateAge <= 40).ToEnumerable();
        //    }
        //    if else (age == "41-50")
        //    {
        //        results = _context.Burial.Where(b => b.EstimateAge > 40 && b.EstimateAge <= 50).ToEnumerable();
        //    }
        //    if else (age == "51-60")
        //    {
        //        results = _context.Burial.Where(b => b.EstimateAge > 50 && b.EstimateAge <= 60).ToEnumerable();
        //    }
        //    if else (age == "61-70")
        //    {
        //        results = _context.Burial.Where(b => b.EstimateAge > 60 && b.EstimateAge <= 70).ToEnumerable();
        //    }
        //    else
        //    {
        //        results = _context.Burial.ToEnumerable();
        //    }
        //    return results;
        //}

        //public IEnumerable<Burial> FilterHeight(IEnumerable<Burial> list, string height)
        //{
        //    var results;

            if (height == "0-.5")
            {
                results = list.Where(b => b.EstimateLivingStature > 0 && b.EstimateLivingStature <= 0.59);
            }
            if else (height == ".6-1")
            {
                results = list.Where(b => b.EstimateLivingStature > 0.59 && b.EstimateLivingStature <= 1.09);
            }
            if else (height == "1.1-1.5")
            {
                results = list.Where(b => b.EstimateLivingStature > 1.09 && b.EstimateLivingStature <= 1.59);
            }
            if else (height == "1.6-2.0")
            {
                results = list.Where(b => b.EstimateLivingStature > 1.59 && b.EstimateLivingStature <= 2.09);
            }
            if else (height == "2.1-2.5")
            {
                results = list.Where(b => b.EstimateLivingStature > 2.09 && b.EstimateLivingStature <= 2.59);
            }
            if else (height == "2.6-3")
            {
                results = list.Where(b => b.EstimateLivingStature > 2.59 && b.EstimateLivingStature <= 3.09);
            }
            else
            {
                results = list;
            }
        }

        //public IEnumerable<Burial> FilterBurialDepth(IEnumerable<Burial> list, string depth) 
        //{
        //    var results;

        //    if (depth == "0-.5")
        //    {
        //        results = list.Where(b => b.BurialDepth > 0 && b.BurialDepth <= 0.59);
        //    }
        //    if else (depth == ".6-1")
        //    {
        //        results = list.Where(b => b.BurialDepth > 0.59 && b.BurialDepth <= 1.09);
        //    }
        //    if else (depth == "1.1-1.5")
        //    {
        //        results = list.Where(b => b.BurialDepth > 1.09 && b.BurialDepth <= 1.59);
        //    }
        //    if else (depth == "1.6-2.0")
        //    {
        //        results = list.Where(b => b.BurialDepth > 1.59 && b.BurialDepth <= 2.09);
        //    }
        //    if else (depth == "2.1-2.5")
        //    {
        //        results = list.Where(b => b.BurialDepth > 2.09 && b.BurialDepth <= 2.59);
        //    }
        //    if else (depth == "2.6-3")
        //    {
        //        results = list.Where(b => b.BurialDepth > 2.59 && b.BurialDepth <= 3.09);
        //    }
        //    if else (depth == "3.1-3.5")
        //    {
        //        results = list.Where(b => b.BurialDepth > 3.09 && b.BurialDepth <= 3.59);
        //    }
        //    if else (depth == "3.6-4")
        //    {
        //        results = list.Where(b => b.BurialDepth > 3.59 && b.BurialDepth <= 4.09);
        //    }
        //    else
        //    {
        //        results = list;
        //    }

        //    return results;
        //}

        //public IEnumerable<Burial> FilterFoundYear(IEnumerable<Burial> list, int year)
        //{
        //    return list.Where(b => b.DateFound.Year == year); //.Year should automatically pull the year from the datetime?
        //}
        
        //public IEnumerable<Burial> FilterFoundMonth(IEnumerable<Burial> list, int month)
        //{
        //    return list.Where(b => b.DateFound.Month == month);
        //}

        //public IEnumerable<Burial> FilterItemFound(IEnumerable<Burial> list, string item)
        //{
        //    return list.Where(b => b.ArtifactFound == item)
        //}
        
        //public IEnumerable<Burial> FilterRemainLength(IEnumerable<Burial> list, string length)
        //{
        //    var results;

        //    if (length == "0-1")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 0 && b.LengthOfRemains <= 1);
        //    }
        //    if else (length == "1-2")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 1.01 && b.LengthOfRemains <= 2);
        //    }
        //    if else (length == "2-3")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 2.01 && b.LengthOfRemains <= 3);
        //    }
        //    if else (length == "3-4")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 3.01 && b.LengthOfRemains <= 4);
        //    }
        //    if else (length == "4-5")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 4.01 && b.LengthOfRemains <= 5);
        //    }
        //    if else (length == "5-6")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 5.01 && b.LengthOfRemains <= 6);
        //    }
        //    if else (length == "6-7")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 6.01 && b.LengthOfRemains <= 7);
        //    }
        //    if else (length == "7-8")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 7.01 && b.LengthOfRemains <= 8);
        //    }
        //    if else (length == "8-9")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 8.01 && b.LengthOfRemains <= 9);
        //    }
        //    if else (length == "9-10")
        //    {
        //        results = list.Where(b => b.LengthOfRemains > 9.01 && b.LengthOfRemains <= 10);
        //    }
        //    else
        //    {
        //        results = list;
        //    }

        //    return results;
        //}
    }
}
