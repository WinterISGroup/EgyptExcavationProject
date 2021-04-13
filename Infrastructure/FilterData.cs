using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EgyptExcavationProject.Infrastructure
{
    public class FilterData
    {
        public string Gender { get; set; }

        public string HairColor { get; set; }

        public string AgeCode { get; set; }

        public string Height { get; set; }

        public string BurialDepth { get; set; }

        public int? DateFoundYear { get; set; }

        public int? DateFoundMonth { get; set; }

        public string ItemFound { get; set; }

        public string LengthOfRemains { get; set; }

        public string TextileFound { get; set; }

        public char? SquareNS { get; set; }

        public int? NSLowPair { get; set; }

        public char? SquareEW { get; set; }

        public int? EWLowPair { get; set; }

        public string SubPlot { get; set; }

        public string HeadDirection { get; set; }

        public string BurialTime { get; set; }
    }
}
