using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class Location
    {
        public Location()
        {
            Burial = new HashSet<Burial>();
        }

        public Guid LocationId { get; set; }
        public char LocationNs { get; set; }
        public char LocationEw { get; set; }
        public int LowPairNs { get; set; }
        public int HighPairNs { get; set; }
        public int LowPairEw { get; set; }
        public int HighPairEw { get; set; }
        public string BurialSubplot { get; set; }

        public virtual ICollection<Burial> Burial { get; set; }
    }
}
