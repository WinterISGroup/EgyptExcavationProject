using EgyptExcavationProject.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Services
{
    public interface IFilterService
    {
        public IEnumerable<Burial> FilterAllData(IFormCollection form);
        public List<Burial> FilterGender(string gender);
        public List<Burial> FilterHairColor(string color);
        //public IEnumerable<Burial> FilterAge(IEnumerable<Burial> list, string age);
        public List<Burial> FilterHeight(string height);
        public IEnumerable<Burial> FilterBurialDepth(IEnumerable<Burial> list, string depth);
        public IEnumerable<Burial> FilterFoundYear(IEnumerable<Burial> list, int year);
        public IEnumerable<Burial> FilterFoundMonth(IEnumerable<Burial> list, int month);
        public IEnumerable<Burial> FilterItemFound(IEnumerable<Burial> list, string item);
        public IEnumerable<Burial> FilterRemainLength(IEnumerable<Burial> list, string length);
        public IEnumerable<Burial> FilterTextile(IEnumerable<Burial> list, bool? textile);
        public IEnumerable<Burial> FilterSquare(IEnumerable<Burial> list, char? NS, int? NSlow, char? EW, int? EWlow);
        public IEnumerable<Burial> FilterArea(IEnumerable<Burial> list, string area);
        public IEnumerable<Burial> FilterHeadDirection(IEnumerable<Burial> list, string direction);
        //public IEnumerable<Burial> FilterTimeOfBurial(IEnumerable<Burial> list, string burial);
    }
}