namespace mentalgrocery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("WalkingList")]
    public partial class WalkingList
    {
        [Key]
        public int waId { get; set; }

        public int? groupId { get; set; }

        [Required]
        [StringLength(50)]
        public string waName { get; set; }

        [StringLength(50)]
        public string waAddress { get; set; }

        [StringLength(50)]
        public string waSuburb { get; set; }

        [StringLength(6)]
        public string waPostCode { get; set; }

        [StringLength(10)]
        public string waState { get; set; }

        [StringLength(20)]
        public string waLGA { get; set; }

        [StringLength(30)]
        public string waRegion { get; set; }

        [StringLength(15)]
        public string waPhone { get; set; }

        [StringLength(50)]
        public string waEmail { get; set; }

        [StringLength(50)]
        public string waWeb { get; set; }

        [StringLength(400)]
        public string waEmbedLink { get; set; }
    }
}
