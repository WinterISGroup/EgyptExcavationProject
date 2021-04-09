using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class Skull
    {
        public Skull()
        {
            Burial = new HashSet<Burial>();
        }

        public Guid SkullId { get; set; }
        public string BasiilarSuture { get; set; }
        public int? Robust { get; set; }
        public int? SupraorbitalRidges { get; set; }
        public int? OrbitalEdge { get; set; }
        public int? ParietalBossing { get; set; }
        public int? Gonion { get; set; }
        public int? ZygomaticCrest { get; set; }
        public int? NuchalCrest { get; set; }
        public int? CranialSuture { get; set; }
        public double? MaximumCranialLength { get; set; }
        public double? MaximumCranialBreadth { get; set; }
        public double? BasionBregmaHeight { get; set; }
        public double? BizygomaticDiameter { get; set; }
        public double? NasionProsthion { get; set; }
        public double? MaximumNasalBreadth { get; set; }
        public double? InterorbitalBreadth { get; set; }
        public int? ToothAttrition { get; set; }
        public string ToothEruption { get; set; }
        public Guid? BurialId { get; set; }
        public string SkullSex { get; set; }
        public string SkullAge { get; set; }
        public double? BasionNasion { get; set; }
        public double? BasionProsthionLength { get; set; }
        public int? SkullYear { get; set; }
        public int? SkullMonth { get; set; }
        public int? SkullDate { get; set; }
        public bool? SkullTrauma { get; set; }
        public bool? SkullAtMagazine { get; set; }
        public bool? CribraOrbitala { get; set; }
        public bool? PoroticHyperostosis { get; set; }
        public bool? ButtonOsteoma { get; set; }
        public bool? HasTmj { get; set; }
        public bool? LinearHypoplasiaEnamel { get; set; }
        public string MetopicSuture { get; set; }
        public string PoroticHyperostosisLocations { get; set; }

        public virtual Burial BurialNavigation { get; set; }
        public virtual ICollection<Burial> Burial { get; set; }
    }
}
