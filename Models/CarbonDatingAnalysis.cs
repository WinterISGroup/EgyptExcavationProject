using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class CarbonDatingAnalysis
    {
        public Guid Carbon14Id { get; set; }
        public Guid? SampleId { get; set; }
        public int? RackNum { get; set; }
        public int? TubeNum { get; set; }
        public string SampleDescription { get; set; }
        public double? Size { get; set; }
        public int? Foci { get; set; }
        public string LocationDescription { get; set; }
        public string Question { get; set; }
        public int? AgeBp { get; set; }
        public string C14CalendarDate { get; set; }
        public string Calibrated95CalendarDateMax { get; set; }
        public string Calibrated95CalendarDateMin { get; set; }
        public string Calibrated95CalendarDateSpan { get; set; }
        public string Calibrated95DateAvg { get; set; }
        public string Notes { get; set; }
        public int? Area { get; set; }
        public string Category { get; set; }

        public virtual BioSample Sample { get; set; }
    }
}
