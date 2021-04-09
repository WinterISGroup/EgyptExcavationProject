using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class Pelvis
    {
        public Pelvis()
        {
            Burial = new HashSet<Burial>();
        }

        public Guid PelvisId { get; set; }
        public int? VentralArc { get; set; }
        public int? SubpubicAngle { get; set; }
        public int? SciaticNotch { get; set; }
        public int? MedialIpRamus { get; set; }
        public string PubicSymphisis { get; set; }
        public int? PubicBone { get; set; }
        public int? PreaurSulcus { get; set; }
        public int? DorsalPitting { get; set; }
        public Guid? BurialId { get; set; }

        public virtual Burial BurialNavigation { get; set; }
        public virtual ICollection<Burial> Burial { get; set; }
    }
}
