namespace TeacherPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Qualification")]
    public partial class Qualification
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(255)]
        public string TID { get; set; }

        [Key]
        [Column("UG/PG/PHD", Order = 1)]
        [StringLength(50)]
        public string UG_PG_PHD { get; set; }

        [Column("University/School")]
        [StringLength(255)]
        public string University_School { get; set; }

        [Column(TypeName = "date")]
        public DateTime? YOP { get; set; }

        [StringLength(255)]
        public string Specification { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
