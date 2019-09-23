namespace TeacherPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Prev_Experience
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string Employer { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(255)]
        public string TID { get; set; }

        [StringLength(255)]
        public string Role { get; set; }

        public DateTime? Start_Date { get; set; }

        public DateTime? End_Date { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
