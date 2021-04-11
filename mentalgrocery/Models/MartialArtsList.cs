namespace mentalgrocery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MartialArtsList")]
    public partial class MartialArtsList
    {
        [Key]
        public int maId { get; set; }

        public int? groupId { get; set; }

        [Required]
        [StringLength(50)]
        public string maName { get; set; }

        [StringLength(50)]
        public string maAddress { get; set; }

        [StringLength(50)]
        public string maSuburb { get; set; }

        [StringLength(6)]
        public string maPostCode { get; set; }

        [StringLength(10)]
        public string maState { get; set; }

        [StringLength(20)]
        public string maLGA { get; set; }

        [StringLength(30)]
        public string maRegion { get; set; }

        [StringLength(15)]
        public string maPhone { get; set; }

        [StringLength(50)]
        public string maEmail { get; set; }

        [StringLength(50)]
        public string maWeb { get; set; }

        [StringLength(400)]
        public string maEmbedLink { get; set; }
    }
}
