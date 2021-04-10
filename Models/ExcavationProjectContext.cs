using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EgyptExcavationProject.Models
{
    public partial class ExcavationProjectContext : DbContext
    {
        public ExcavationProjectContext()
        {
        }

        public ExcavationProjectContext(DbContextOptions<ExcavationProjectContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BioSample> BioSample { get; set; }
        public virtual DbSet<Burial> Burial { get; set; }
        public virtual DbSet<CarbonDatingAnalysis> CarbonDatingAnalysis { get; set; }
        public virtual DbSet<Femur> Femur { get; set; }
        public virtual DbSet<Humerus> Humerus { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Pelvis> Pelvis { get; set; }
        public virtual DbSet<Skull> Skull { get; set; }
        public virtual DbSet<Tibia> Tibia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=192.168.50.208;Database=ExcavationProject;Username=postgres;Password=konojo");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BioSample>(entity =>
            {
                entity.HasKey(e => e.SampleId)
                    .HasName("bio_samples_pkey");

                entity.ToTable("bio_sample");

                entity.Property(e => e.SampleId)
                    .HasColumnName("sample_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BagNum).HasColumnName("bag_num");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSubplot).HasColumnName("burial_subplot");

                entity.Property(e => e.ClusterNum).HasColumnName("cluster_num");

                entity.Property(e => e.Initials).HasColumnName("initials");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.PreviouslySampled).HasColumnName("previously_sampled");

                entity.Property(e => e.RackNum).HasColumnName("rack_num");

                entity.Property(e => e.ResearchInitials)
                    .HasColumnName("research_initials")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.YearFound).HasColumnName("year_found");

                entity.HasOne(d => d.Burial)
                    .WithMany(p => p.BioSample)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("bio_samples_burial_id_fkey");
            });

            modelBuilder.Entity<Burial>(entity =>
            {
                entity.ToTable("burial");

                entity.Property(e => e.BurialId)
                    .HasColumnName("burial_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeCode).HasColumnName("age_code");

                entity.Property(e => e.ArtifactFound)
                    .HasColumnName("artifact_found")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.ArtifactsDescription)
                    .HasColumnName("artifacts_description")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.BodyAnalysisYear).HasColumnName("body_analysis_year");

                entity.Property(e => e.BoneTaken)
                    .HasColumnName("bone_taken")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.BurialAdultChild).HasColumnName("burial_adult_child");

                entity.Property(e => e.BurialAge).HasColumnName("burial_age");

                entity.Property(e => e.BurialDepth).HasColumnName("burial_depth");

                entity.Property(e => e.BurialGenderMethod).HasColumnName("burial_gender_method");

                entity.Property(e => e.BurialMaterials).HasColumnName("burial_materials");

                entity.Property(e => e.BurialNumber).HasColumnName("burial_number");

                entity.Property(e => e.BurialSampleTaken).HasColumnName("burial_sample_taken");

                entity.Property(e => e.BurialWrapping).HasColumnName("burial_wrapping");

                entity.Property(e => e.CalculatedLengthOfRemains).HasColumnName("calculated_length_of_remains");

                entity.Property(e => e.Cluster).HasColumnName("cluster");

                entity.Property(e => e.ClusterNumber).HasColumnName("cluster_number");

                entity.Property(e => e.DateFound)
                    .HasColumnName("date_found")
                    .HasColumnType("date");

                entity.Property(e => e.DescriptionOfTaken)
                    .HasColumnName("description_of_taken")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.EstimateAge).HasColumnName("estimate_age");

                entity.Property(e => e.EstimateLivingStature).HasColumnName("estimate_living_stature");

                entity.Property(e => e.ExcavationRecorder).HasColumnName("excavation_recorder");

                entity.Property(e => e.FaceBundle).HasColumnName("face_bundle");

                entity.Property(e => e.FemurId).HasColumnName("femur_id");

                entity.Property(e => e.FieldBook).HasColumnName("field_book");

                entity.Property(e => e.FieldBookPageNumber).HasColumnName("field_book_page_number");

                entity.Property(e => e.GeFunctionTotal).HasColumnName("GE_function_total");

                entity.Property(e => e.GenderBodyCol).HasColumnName("gender_body_col");

                entity.Property(e => e.GenderGe).HasColumnName("gender_GE");

                entity.Property(e => e.Goods).HasColumnName("goods");

                entity.Property(e => e.HairColor)
                    .HasColumnName("hair_color")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.HairPresent).HasColumnName("hair_present");

                entity.Property(e => e.HairTaken)
                    .HasColumnName("hair_taken")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.HasByuSample).HasColumnName("has_byu_sample");

                entity.Property(e => e.HeadDirection)
                    .HasColumnName("head_direction")
                    .HasDefaultValueSql("'''U'''::text");

                entity.Property(e => e.HillArea).HasColumnName("hill_area");

                entity.Property(e => e.HumerusId).HasColumnName("humerus_id");

                entity.Property(e => e.LengthOfRemains).HasColumnName("length_of_remains");

                entity.Property(e => e.LocationId).HasColumnName("location_id");

                entity.Property(e => e.NeedsConfirmation).HasColumnName("needs_confirmation");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.OsteologyNotes).HasColumnName("osteology_notes");

                entity.Property(e => e.OsteologyUnknownComment).HasColumnName("osteology_unknown_comment");

                entity.Property(e => e.Osteophytosis)
                    .HasColumnName("osteophytosis")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.PathologyAnomalies)
                    .HasColumnName("pathology_anomalies")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.PelvisId).HasColumnName("pelvis_id");

                entity.Property(e => e.Photo).HasColumnName("photo");

                entity.Property(e => e.PostcraniaAtMagazine).HasColumnName("postcrania_at_magazine");

                entity.Property(e => e.PostcraniaTrauma).HasColumnName("postcrania_trauma");

                entity.Property(e => e.PreservationComments).HasColumnName("preservation_comments");

                entity.Property(e => e.PreservationIndex)
                    .HasColumnName("preservation_index")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.RackShelf).HasColumnName("rack_shelf");

                entity.Property(e => e.RelatedBurialNumbers).HasColumnName("related_burial_numbers");

                entity.Property(e => e.SampleNumber).HasColumnName("sample_number");

                entity.Property(e => e.Shaft).HasColumnName("shaft");

                entity.Property(e => e.SharedShaft).HasColumnName("shared_shaft");

                entity.Property(e => e.SkullId).HasColumnName("skull_id");

                entity.Property(e => e.SoftTissueTaken)
                    .HasColumnName("soft_tissue_taken")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.SouthToFeet).HasColumnName("south_to_feet");

                entity.Property(e => e.SouthToHead).HasColumnName("south_to_head");

                entity.Property(e => e.TextileTaken).HasColumnName("textile_taken");

                entity.Property(e => e.TibiaId).HasColumnName("tibia_id");

                entity.Property(e => e.Tomb).HasColumnName("tomb");

                entity.Property(e => e.ToothTaken)
                    .HasColumnName("tooth_taken")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.WestToFeet).HasColumnName("west_to_feet");

                entity.Property(e => e.WestToHead).HasColumnName("west_to_head");

                entity.HasOne(d => d.Femur)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.FemurId)
                    .HasConstraintName("burials_femur_id_fkey");

                entity.HasOne(d => d.Humerus)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.HumerusId)
                    .HasConstraintName("burials_humerus_id_fkey");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("burials_location_id_fkey");

                entity.HasOne(d => d.Pelvis)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.PelvisId)
                    .HasConstraintName("burials_pelvis_id_fkey");

                entity.HasOne(d => d.Skull)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.SkullId)
                    .HasConstraintName("burials_skull_id_fkey");

                entity.HasOne(d => d.Tibia)
                    .WithMany(p => p.Burial)
                    .HasForeignKey(d => d.TibiaId)
                    .HasConstraintName("burials_tibia_id_fkey");
            });

            modelBuilder.Entity<CarbonDatingAnalysis>(entity =>
            {
                entity.HasKey(e => e.Carbon14Id)
                    .HasName("carbon_dating_analyses_pkey");

                entity.ToTable("carbon_dating_analysis");

                entity.Property(e => e.Carbon14Id)
                    .HasColumnName("carbon14_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AgeBp).HasColumnName("age_bp");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.C14CalendarDate)
                    .HasColumnName("c14_calendar_date")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.Calibrated95CalendarDateMax)
                    .HasColumnName("calibrated_95_calendar_date_max")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.Calibrated95CalendarDateMin)
                    .HasColumnName("calibrated_95_calendar_date_min")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.Calibrated95CalendarDateSpan)
                    .HasColumnName("calibrated_95_calendar_date_span")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.Calibrated95DateAvg)
                    .HasColumnName("calibrated_95_date_avg")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.Foci).HasColumnName("foci");

                entity.Property(e => e.LocationDescription)
                    .HasColumnName("location_description")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.Notes)
                    .HasColumnName("notes")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.Question)
                    .HasColumnName("question")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.RackNum).HasColumnName("rack_num");

                entity.Property(e => e.SampleDescription)
                    .HasColumnName("sample_description")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.SampleId).HasColumnName("sample_id");

                entity.Property(e => e.Size).HasColumnName("size");

                entity.Property(e => e.TubeNum).HasColumnName("tube_num");

                entity.HasOne(d => d.Sample)
                    .WithMany(p => p.CarbonDatingAnalysis)
                    .HasForeignKey(d => d.SampleId)
                    .HasConstraintName("carbon_dating_analyses_sample_id_fkey");
            });

            modelBuilder.Entity<Femur>(entity =>
            {
                entity.ToTable("femur");

                entity.Property(e => e.FemurId)
                    .HasColumnName("femur_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.EpiphysealUnion)
                    .HasColumnName("epiphyseal_union")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.FemurHead).HasColumnName("femur_head");

                entity.Property(e => e.FemurLength).HasColumnName("femur_length");

                entity.HasOne(d => d.BurialNavigation)
                    .WithMany(p => p.FemurNavigation)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("femurs_burial_id_fkey");
            });

            modelBuilder.Entity<Humerus>(entity =>
            {
                entity.ToTable("humerus");

                entity.Property(e => e.HumerusId)
                    .HasColumnName("humerus_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.EpiphysealUnion).HasColumnName("epiphyseal_union");

                entity.Property(e => e.HumerusHead).HasColumnName("humerus_head");

                entity.Property(e => e.HumerusLength).HasColumnName("humerus_length");

                entity.HasOne(d => d.BurialNavigation)
                    .WithMany(p => p.HumerusNavigation)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("humeri_burial_id_fkey");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("location");

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialSubplot)
                    .HasColumnName("burial_subplot")
                    .HasDefaultValueSql("'U'::text");

                entity.Property(e => e.HighPairEw)
                    .HasColumnName("high_pair_EW")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HighPairNs)
                    .HasColumnName("high_pair_NS")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LocationEw)
                    .HasColumnName("location_EW")
                    .HasDefaultValueSql("'U'::bpchar");

                entity.Property(e => e.LocationNs)
                    .HasColumnName("location_NS")
                    .HasDefaultValueSql("'U'::bpchar");

                entity.Property(e => e.LowPairEw)
                    .HasColumnName("low_pair_EW")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LowPairNs)
                    .HasColumnName("low_pair_NS")
                    .HasDefaultValueSql("0");
            });

            modelBuilder.Entity<Pelvis>(entity =>
            {
                entity.ToTable("pelvis");

                entity.Property(e => e.PelvisId)
                    .HasColumnName("pelvis_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.DorsalPitting).HasColumnName("dorsal_pitting");

                entity.Property(e => e.MedialIpRamus).HasColumnName("medial_IP_ramus");

                entity.Property(e => e.PreaurSulcus).HasColumnName("preaur_sulcus");

                entity.Property(e => e.PubicBone).HasColumnName("pubic_bone");

                entity.Property(e => e.PubicSymphisis)
                    .HasColumnName("pubic_symphisis")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.SciaticNotch).HasColumnName("sciatic_notch");

                entity.Property(e => e.SubpubicAngle).HasColumnName("subpubic_angle");

                entity.Property(e => e.VentralArc).HasColumnName("ventral_arc");

                entity.HasOne(d => d.BurialNavigation)
                    .WithMany(p => p.PelvisNavigation)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("pelves_burial_id_fkey");
            });

            modelBuilder.Entity<Skull>(entity =>
            {
                entity.ToTable("skull");

                entity.Property(e => e.SkullId)
                    .HasColumnName("skull_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BasilarSuture)
                    .HasColumnName("basilar_suture")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.BasionBregmaHeight).HasColumnName("basion_bregma_height");

                entity.Property(e => e.BasionNasion).HasColumnName("basion_nasion");

                entity.Property(e => e.BasionProsthionLength).HasColumnName("basion_prosthion_length");

                entity.Property(e => e.BizygomaticDiameter).HasColumnName("bizygomatic_diameter");

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.ButtonOsteoma).HasColumnName("button_osteoma");

                entity.Property(e => e.CranialSuture).HasColumnName("cranial_suture");

                entity.Property(e => e.CribraOrbitala).HasColumnName("cribra_orbitala");

                entity.Property(e => e.Gonion).HasColumnName("gonion");

                entity.Property(e => e.HasTmj).HasColumnName("has_tmj");

                entity.Property(e => e.InterorbitalBreadth).HasColumnName("interorbital_breadth");

                entity.Property(e => e.LinearHypoplasiaEnamel).HasColumnName("linear_hypoplasia_enamel");

                entity.Property(e => e.MaximumCranialBreadth).HasColumnName("maximum_cranial_breadth");

                entity.Property(e => e.MaximumCranialLength).HasColumnName("maximum_cranial_length");

                entity.Property(e => e.MaximumNasalBreadth).HasColumnName("maximum_nasal_breadth");

                entity.Property(e => e.MetopicSuture).HasColumnName("metopic_suture");

                entity.Property(e => e.NasionProsthion).HasColumnName("nasion_prosthion");

                entity.Property(e => e.NuchalCrest).HasColumnName("nuchal_crest");

                entity.Property(e => e.OrbitalEdge).HasColumnName("orbital_edge");

                entity.Property(e => e.ParietalBossing).HasColumnName("parietal_bossing");

                entity.Property(e => e.PoroticHyperostosis).HasColumnName("porotic_hyperostosis");

                entity.Property(e => e.PoroticHyperostosisLocations).HasColumnName("porotic_hyperostosis_locations");

                entity.Property(e => e.Robust).HasColumnName("robust");

                entity.Property(e => e.SkullAge).HasColumnName("skull_age");

                entity.Property(e => e.SkullAtMagazine).HasColumnName("skull_at_magazine");

                entity.Property(e => e.SkullDate).HasColumnName("skull_date");

                entity.Property(e => e.SkullMonth).HasColumnName("skull_month");

                entity.Property(e => e.SkullSex).HasColumnName("skull_sex");

                entity.Property(e => e.SkullTrauma).HasColumnName("skull_trauma");

                entity.Property(e => e.SkullYear).HasColumnName("skull_year");

                entity.Property(e => e.SupraorbitalRidges).HasColumnName("supraorbital_ridges");

                entity.Property(e => e.ToothAttrition).HasColumnName("tooth_attrition");

                entity.Property(e => e.ToothEruption)
                    .HasColumnName("tooth_eruption")
                    .HasDefaultValueSql("'NULL'::text");

                entity.Property(e => e.ZygomaticCrest).HasColumnName("zygomatic_crest");

                entity.HasOne(d => d.BurialNavigation)
                    .WithMany(p => p.SkullNavigation)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("skulls_burial_id_fkey");
            });

            modelBuilder.Entity<Tibia>(entity =>
            {
                entity.ToTable("tibia");

                entity.Property(e => e.TibiaId)
                    .HasColumnName("tibia_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BurialId).HasColumnName("burial_id");

                entity.Property(e => e.TibiaLength).HasColumnName("tibia_length");

                entity.HasOne(d => d.BurialNavigation)
                    .WithMany(p => p.TibiaNavigation)
                    .HasForeignKey(d => d.BurialId)
                    .HasConstraintName("tibias_burial_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
