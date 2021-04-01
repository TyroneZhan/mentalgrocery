using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace mentalgrocery.Models
{
    public partial class webModels : DbContext
    {
        public webModels()
            : base("name=webModels")
        {
        }

        public virtual DbSet<CanoesKayaktsList> CanoesKayaktsLists { get; set; }
        public virtual DbSet<GroupList> GroupLists { get; set; }
        public virtual DbSet<MartialArtsList> MartialArtsLists { get; set; }
        public virtual DbSet<VolunteeringList> VolunteeringLists { get; set; }
        public virtual DbSet<WalkingList> WalkingLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckName)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckSuburb)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckPostCode)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckState)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckLGA)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckRegion)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckPhone)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckEmail)
                .IsUnicode(false);

            modelBuilder.Entity<CanoesKayaktsList>()
                .Property(e => e.ckWeb)
                .IsUnicode(false);

            modelBuilder.Entity<GroupList>()
                .Property(e => e.groupName)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maName)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maAddress)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maSuburb)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maPostCode)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maState)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maLGA)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maRegion)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maPhone)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maEmail)
                .IsUnicode(false);

            modelBuilder.Entity<MartialArtsList>()
                .Property(e => e.maWeb)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voName)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voAddress)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voSuburb)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.vpPostCode)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.vpState)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voLGA)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voRegion)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voPhone)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voEmail)
                .IsUnicode(false);

            modelBuilder.Entity<VolunteeringList>()
                .Property(e => e.voWeb)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waName)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waAddress)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waSuburb)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waPostCode)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waState)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waLGA)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waRegion)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waPhone)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waEmail)
                .IsUnicode(false);

            modelBuilder.Entity<WalkingList>()
                .Property(e => e.waWeb)
                .IsUnicode(false);
        }
    }
}
