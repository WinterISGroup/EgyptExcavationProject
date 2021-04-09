using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Models.ViewModels
{
    public class BurialViewModel
    {
        public List<Burial> Burials { get; set; }
        public PageNumInfo PageNumInfo { get; set;}
    }
}
