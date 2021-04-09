using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class Femur
    {
        public Femur()
        {
            Burial = new HashSet<Burial>();
        }

        public Guid FemurId { get; set; }
        public double? FemurHead { get; set; }
        public string EpiphysealUnion { get; set; }
        public double? FemurLength { get; set; }
        public Guid? BurialId { get; set; }

        public virtual Burial BurialNavigation { get; set; }
        public virtual ICollection<Burial> Burial { get; set; }
    }
}
