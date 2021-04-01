namespace mentalgrocery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VolunteeringList")]
    public partial class VolunteeringList
    {
        [Key]
        public int voId { get; set; }

        public int? groupId { get; set; }

        [Required]
        [StringLength(50)]
        public string voName { get; set; }

        [StringLength(50)]
        public string voAddress { get; set; }

        [StringLength(50)]
        public string voSuburb { get; set; }

        [StringLength(6)]
        public string vpPostCode { get; set; }

        [StringLength(10)]
        public string vpState { get; set; }

        [StringLength(20)]
        public string voLGA { get; set; }

        [StringLength(30)]
        public string voRegion { get; set; }

        [StringLength(15)]
        public string voPhone { get; set; }

        [StringLength(50)]
        public string voEmail { get; set; }

        [StringLength(50)]
        public string voWeb { get; set; }
    }
}
