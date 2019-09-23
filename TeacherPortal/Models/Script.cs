namespace TeacherPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Script
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Subj_Id { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Year { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(255)]
        public string TID { get; set; }

        public int? No_Of_Scripts { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
