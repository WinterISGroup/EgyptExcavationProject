using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class BioSample
    {
        public BioSample()
        {
            CarbonDatingAnalysis = new HashSet<CarbonDatingAnalysis>();
        }

        public Guid SampleId { get; set; }
        public Guid? BurialId { get; set; }
        public DateTime? YearFound { get; set; }
        public int? ClusterNum { get; set; }
        public bool PreviouslySampled { get; set; }
        public string Notes { get; set; }
        public string ResearchInitials { get; set; }
        public int? BurialNumber { get; set; }
        public int? SampleNumber { get; set; }
        public string BurialSubplot { get; set; }
        public int? RackNum { get; set; }
        public int? BagNum { get; set; }
        public string Initials { get; set; }

        public virtual Burial Burial { get; set; }
        public virtual ICollection<CarbonDatingAnalysis> CarbonDatingAnalysis { get; set; }
    }
}
