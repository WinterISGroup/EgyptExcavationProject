using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class Humerus
    {
        public Humerus()
        {
            Burial = new HashSet<Burial>();
        }

        public Guid HumerusId { get; set; }
        public double? HumerusHead { get; set; }
        public double? EpiphysealUnion { get; set; }
        public double? HumerusLength { get; set; }
        public Guid? BurialId { get; set; }

        public virtual Burial BurialNavigation { get; set; }
        public virtual ICollection<Burial> Burial { get; set; }
    }
}
