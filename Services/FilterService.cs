using EgyptExcavationProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Services
{
    public class FilterService : IFilterService
    {
        private ExcavationProjectContext _context { get; set; }

        public FilterService(ExcavationProjectContext con)
        {
            _context = con;
        }



    }
}
