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
        
        //Ask about the gender columns.
        public IEnumerable<Burial> FilterGender( string gender)
        {
            gender = gender.ToUpper();

            if (gender == "")
            {
                return _context.Burial;
            }
            else
            {
                return _context.Burial.Where(b => b.GenderGe == gender);
            }
        }

        public IEnumerable<Burial> FilterHairColor(IEnumerable<Burial> list, string color)
        {
            return list.Where(b => b.HairColor.Contains(color));
        }

        //Age is first filter. Starts the initial filter from the context
        //Need to somehow filter the age from the string data
        public IEnumerable<Burial> FilterAge(IEnumerable<Burial> list, string age)
        {
            if (age == "0-10")
            {
                return list.Where(b => b.EstimateAge > 0 && b.EstimateAge <= 10);
            }
            else if (age == "11-20")
            {
                return list.Where(b => b.EstimateAge > 10 && b.EstimateAge <= 20);
            }
            else if (age == "21-30")
            {
                return list.Where(b => b.EstimateAge > 20 && b.EstimateAge <= 30);
            }
            else if (age == "31-40")
            {
                return list.Where(b => b.EstimateAge > 30 && b.EstimateAge <= 40);
            }
            else if (age == "41-50")
            {
                return list.Where(b => b.EstimateAge > 40 && b.EstimateAge <= 50);
            }
            else if (age == "51-60")
            {
                return list.Where(b => b.EstimateAge > 50 && b.EstimateAge <= 60);
            }
            else if (age == "61-70")
            {
                return list.Where(b => b.EstimateAge > 60 && b.EstimateAge <= 70);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Burial> FilterHeight(IEnumerable<Burial> list, string height)
        {
            if (height == "0-.5")
            {
                return list.Where(b => b.EstimateLivingStature > 0 && b.EstimateLivingStature <= 0.59);
            }
            else if (height == ".6-1")
            {
                return list.Where(b => b.EstimateLivingStature > 0.59 && b.EstimateLivingStature <= 1.09);
            }
            else if (height == "1.1-1.5")
            {
                return list.Where(b => b.EstimateLivingStature > 1.09 && b.EstimateLivingStature <= 1.59);
            }
            else if (height == "1.6-2.0")
            {
                return list.Where(b => b.EstimateLivingStature > 1.59 && b.EstimateLivingStature <= 2.09);
            }
            else if (height == "2.1-2.5")
            {
                return list.Where(b => b.EstimateLivingStature > 2.09 && b.EstimateLivingStature <= 2.59);
            }
            else if (height == "2.6-3")
            {
                return list.Where(b => b.EstimateLivingStature > 2.59 && b.EstimateLivingStature <= 3.09);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Burial> FilterBurialDepth(IEnumerable<Burial> list, string depth) 
        {
            if (depth == "0-.5")
            {
                return list.Where(b => b.BurialDepth > 0 && b.BurialDepth <= 0.59);
            }
            else if (depth == ".6-1")
            {
                return list.Where(b => b.BurialDepth > 0.59 && b.BurialDepth <= 1.09);
            }
            else if (depth == "1.1-1.5")
            {
                return list.Where(b => b.BurialDepth > 1.09 && b.BurialDepth <= 1.59);
            }
            else if (depth == "1.6-2.0")
            {
                return list.Where(b => b.BurialDepth > 1.59 && b.BurialDepth <= 2.09);
            }
            else if (depth == "2.1-2.5")
            {
                return list.Where(b => b.BurialDepth > 2.09 && b.BurialDepth <= 2.59);
            }
            else if (depth == "2.6-3")
            {
                return list.Where(b => b.BurialDepth > 2.59 && b.BurialDepth <= 3.09);
            }
            else if (depth == "3.1-3.5")
            {
                return list.Where(b => b.BurialDepth > 3.09 && b.BurialDepth <= 3.59);
            }
            else if (depth == "3.6-4")
            {
                return list.Where(b => b.BurialDepth > 3.59 && b.BurialDepth <= 4.09);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Burial> FilterFoundYear(IEnumerable<Burial> list, int year)
        {
            return list.Where(b => b.DateFound.Value.Year == year); //.Year should automatically pull the year from the datetime?
        }
        
        public IEnumerable<Burial> FilterFoundMonth(IEnumerable<Burial> list, int month)
        {
            return list.Where(b => b.DateFound.Value.Month == month);
        }

        public IEnumerable<Burial> FilterItemFound(IEnumerable<Burial> list, string item)
        {
            return list.Where(b => b.Goods == item);
        }
        
        public IEnumerable<Burial> FilterRemainLength(IEnumerable<Burial> list, string length)
        {
            if (length == "0-1")
            {
                return list.Where(b => b.LengthOfRemains > 0 && b.LengthOfRemains <= 1);
            }
            else if (length == "1-2")
            {
                return list.Where(b => b.LengthOfRemains > 1.01 && b.LengthOfRemains <= 2);
            }
            else if (length == "2-3")
            {
                return list.Where(b => b.LengthOfRemains > 2.01 && b.LengthOfRemains <= 3);
            }
            else if (length == "3-4")
            {
                return list.Where(b => b.LengthOfRemains > 3.01 && b.LengthOfRemains <= 4);
            }
            else if (length == "4-5")
            {
                return list.Where(b => b.LengthOfRemains > 4.01 && b.LengthOfRemains <= 5);
            }
            else if (length == "5-6")
            {
                return list.Where(b => b.LengthOfRemains > 5.01 && b.LengthOfRemains <= 6);
            }
            else if (length == "6-7")
            {
                return list.Where(b => b.LengthOfRemains > 6.01 && b.LengthOfRemains <= 7);
            }
            else if (length == "7-8")
            {
                return list.Where(b => b.LengthOfRemains > 7.01 && b.LengthOfRemains <= 8);
            }
            else if (length == "8-9")
            {
                return list.Where(b => b.LengthOfRemains > 8.01 && b.LengthOfRemains <= 9);
            }
            else if (length == "9-10")
            {
                return list.Where(b => b.LengthOfRemains > 9.01 && b.LengthOfRemains <= 10);
            }
            else
            {
                return list;
            }
        }

        public IEnumerable<Burial> FilterTextile(IEnumerable<Burial> list, bool? textile)
        {
            return list.Where(b => b.TextileTaken == textile);
        }

        //Will it need to reference the locations table?
        public IEnumerable<Burial> FilterSquare(IEnumerable<Burial> list, char? NS, int? NSlow, char? EW, int? EWlow)
        {
            return list.Where(b => b.Location.LocationNs == NS && b.Location.LowPairNs == NSlow &&
                                   b.Location.LocationEw == EW && b.Location.LowPairEw == EWlow);
        }

        //Reference to locations table
        public IEnumerable<Burial> FilterArea(IEnumerable<Burial> list, string area)
        {
            return list.Where(b => b.Location.BurialSubplot == area);
        }

        public IEnumerable<Burial> FilterHeadDirection(IEnumerable<Burial> list, string direction)
        {
            return list.Where(b => b.HeadDirection == direction);
        }

        //Uses carbon dating analyses. May need to loop if multiple biosamples or 
        public IEnumerable<Burial> FilterTimeOfBurial(IEnumerable<Burial> list, string burial)
        {
            return list.Where(b => b.BioSample.FirstOrDefault().CarbonDatingAnalysis.FirstOrDefault().C14CalendarDate == 
        }

        //Main function to utilize all the individual functions. Will be called in controller
        public IEnumerable<Burial> FilterAllData (string gender ="", string hair ="", string age ="", string height="", 
                                                  string depth = "", int year = 0, int month = 0, string item ="", string length ="",
                                                  bool? textile = null, char? NS = null, int? NSlow = null, char? EW = null,
                                                  int? EWlow = null, string area = "", string hDirection = "", string burialTime = "")
        {
            IEnumerable<Burial> results;

            results = FilterGender(gender);

            if(hair != "")
            {
                results = FilterHairColor(results, hair);
            }
            if(age != "")
            {
                results = FilterAge(results, age);
            }
            if(height != "")
            {
                results = FilterHeight(results, height);
            }
            if(depth != "")
            {
                results = FilterBurialDepth(results, depth);
            }
            if(year != 0)
            {
                results = FilterFoundYear(results, year);
            }
            if(month != 0)
            {
                results = FilterFoundMonth(results, month);
            }
            if(item != "")
            {
                results = FilterItemFound(results, item);
            }
            if(length != "")
            {
                results = FilterRemainLength(results, length);
            }
            if(textile != null)
            {
                results = FilterTextile(results, textile);
            }
            if(NS != null && NSlow != null && EW != null && EWlow != null)
            {
                results = FilterSquare(results, NS, NSlow, EW, EWlow);
            }
            if(area != "")
            {
                results = FilterArea(results, area);
            }
            if(hDirection != "")
            {
                results = FilterHeadDirection(results, hDirection);
            }
            if (burialTime != "")
            {
                results = FilterTimeOfBurial(results, burialTime);
            }


        //    return results;
        //}
    }
}
