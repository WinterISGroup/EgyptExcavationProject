using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class Burial
    {
        public Burial()
        {
            BioSample = new HashSet<BioSample>();
            FemurNavigation = new HashSet<Femur>();
            HumerusNavigation = new HashSet<Humerus>();
            PelvisNavigation = new HashSet<Pelvis>();
            SkullNavigation = new HashSet<Skull>();
            TibiaNavigation = new HashSet<Tibia>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BurialId { get; set; }
        public string HeadDirection { get; set; }
        public double? BurialDepth { get; set; }
        public double? SouthToHead { get; set; }
        public double? SouthToFeet { get; set; }
        public double? WestToHead { get; set; }
        public double? WestToFeet { get; set; }
        public string EstimateAge { get; set; }
        public double? EstimateLivingStature { get; set; }
        public string Osteophytosis { get; set; }
        public string PathologyAnomalies { get; set; }
        public string ArtifactsDescription { get; set; }
        public string HairColor { get; set; }
        public string PreservationIndex { get; set; }
        public bool? ArtifactFound { get; set; }
        public string DescriptionOfTaken { get; set; }
        public bool? HairTaken { get; set; }
        public bool? SoftTissueTaken { get; set; }
        public bool? BoneTaken { get; set; }
        public bool? ToothTaken { get; set; }
        public string Notes { get; set; }
        public Guid? LocationId { get; set; }
        public Guid? SkullId { get; set; }
        public Guid? PelvisId { get; set; }
        public DateTime? DateFound { get; set; }
        public Guid? FemurId { get; set; }
        public Guid? HumerusId { get; set; }
        public Guid? TibiaId { get; set; }
        public int? BodyAnalysisYear { get; set; }
        public bool? NeedsConfirmation { get; set; }
        public double? LengthOfRemains { get; set; }
        public int? BurialNumber { get; set; }
        public int? SampleNumber { get; set; }
        public string GenderGe { get; set; }
        public string GenderBodyCol { get; set; }
        public bool? TextileTaken { get; set; }
        public bool? PostcraniaAtMagazine { get; set; }
        public bool? PostcraniaTrauma { get; set; }
        public bool? HasByuSample { get; set; }
        public string PreservationComments { get; set; }
        public string BurialWrapping { get; set; }
        public string BurialAdultChild { get; set; }
        public string BurialGenderMethod { get; set; }
        public string AgeCode { get; set; }
        public double? GeFunctionTotal { get; set; }
        public string BurialAge { get; set; }
        public bool? BurialSampleTaken { get; set; }
        public string Goods { get; set; }
        public bool? FaceBundle { get; set; }
        public string FieldBook { get; set; }
        public string FieldBookPageNumber { get; set; }
        public string OsteologyUnknownComment { get; set; }
        public string RackShelf { get; set; }
        public string HillArea { get; set; }
        public string Tomb { get; set; }
        public string OsteologyNotes { get; set; }
        public string ExcavationRecorder { get; set; }
        public string Shaft { get; set; }
        public string Cluster { get; set; }
        public string SharedShaft { get; set; }
        public int? ClusterNumber { get; set; }
        public double? CalculatedLengthOfRemains { get; set; }
        public string BurialMaterials { get; set; }
        public string Photo { get; set; }
        public string HairPresent { get; set; }
        public string RelatedBurialNumbers { get; set; }

        public virtual Femur Femur { get; set; }
        public virtual Humerus Humerus { get; set; }
        public virtual Location Location { get; set; }
        public virtual Pelvis Pelvis { get; set; }
        public virtual Skull Skull { get; set; }
        public virtual Tibia Tibia { get; set; }
        public virtual ICollection<BioSample> BioSample { get; set; }
        public virtual ICollection<Femur> FemurNavigation { get; set; }
        public virtual ICollection<Humerus> HumerusNavigation { get; set; }
        public virtual ICollection<Pelvis> PelvisNavigation { get; set; }
        public virtual ICollection<Skull> SkullNavigation { get; set; }
        public virtual ICollection<Tibia> TibiaNavigation { get; set; }
    }
}
