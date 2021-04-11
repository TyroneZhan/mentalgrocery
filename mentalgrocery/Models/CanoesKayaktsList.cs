namespace mentalgrocery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CanoesKayaktsList")]
    public partial class CanoesKayaktsList
    {
        [Key]
        public int ckId { get; set; }

        public int? groupId { get; set; }

        [Required]
        [StringLength(50)]
        public string ckName { get; set; }

        [StringLength(50)]
        public string ckAddress { get; set; }

        [StringLength(50)]
        public string ckSuburb { get; set; }

        [StringLength(6)]
        public string ckPostCode { get; set; }

        [StringLength(10)]
        public string ckState { get; set; }

        [StringLength(20)]
        public string ckLGA { get; set; }

        [StringLength(30)]
        public string ckRegion { get; set; }

        [StringLength(15)]
        public string ckPhone { get; set; }

        [StringLength(50)]
        public string ckEmail { get; set; }

        [StringLength(50)]
        public string ckWeb { get; set; }

        [StringLength(400)]
        public string ckEmbedLink { get; set; }
    }
}
