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
        public List<Burial> FilterAllData(IFormCollection form);
        public List<Burial> FilterGender(List<Burial> list, string gender);
        public List<Burial> FilterHairColor(List<Burial> list, string color);
        //public IEnumerable<Burial> FilterAge(IEnumerable<Burial> list, string age);
        public List<Burial> FilterHeight(List<Burial> list, string height);
        public List<Burial> FilterBurialDepth(List<Burial> list, string depth);
        public List<Burial> FilterFoundYear(List<Burial> list, int? year);
        public List<Burial> FilterFoundMonth(List<Burial> list, int? month);
        public List<Burial> FilterItemFound(List<Burial> list, string? item);
        public List<Burial> FilterRemainLength(List<Burial> list, string length);
        public List<Burial> FilterTextile(List<Burial> list, bool? textile);
        public List<Burial> FilterSquare(List<Burial> list, char? NS, int? NSlow, char? EW, int? EWlow);
        public List<Burial> FilterArea(List<Burial> list, string area);
        public List<Burial> FilterHeadDirection(List<Burial> list, string direction);
        //public List<Burial> FilterTimeOfBurial(List<Burial> list, string burial);
    }
}