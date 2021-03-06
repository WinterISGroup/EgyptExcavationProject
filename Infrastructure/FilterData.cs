using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Object FilterData to hold the variables to be used in the record service, and pass the values for filtering and pagination.
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

        public string NSLowPair { get; set; }

        public string NSHighPair { get; set; }

        public char? SquareEW { get; set; }

        public string EWLowPair { get; set; }
        
        public string EWHighPair { get; set; }

        public string SubPlot { get; set; }

        public string HeadDirection { get; set; }

        public string BurialTime { get; set; }
    }
}
