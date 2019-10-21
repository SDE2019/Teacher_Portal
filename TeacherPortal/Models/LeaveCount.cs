namespace TeacherPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LeaveCount")]
    public partial class LeaveCount
    {
        [StringLength(255)]
        public string Id { get; set; }

        public int CL { get; set; }

        public int EL { get; set; }

        public int RH { get; set; }

        public int OOD { get; set; }

        public int Commuted { get; set; }

        public int LWP { get; set; }
    }
}
