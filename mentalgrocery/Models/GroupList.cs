namespace mentalgrocery.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GroupList")]
    public partial class GroupList
    {
        [Key]
        public int groupId { get; set; }

        [Required]
        [StringLength(50)]
        public string groupName { get; set; }
    }
}
