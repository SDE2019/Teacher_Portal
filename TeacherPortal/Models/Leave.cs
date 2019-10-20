namespace TeacherPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Leave")]
    public partial class Leave
    {
        public long LeaveID { get; set; }

        [StringLength(255)]
        public string Id { get; set; }

        [StringLength(255)]
        public string LeaveDescription { get; set; }

        public int? TempContact { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? EndDate { get; set; }

        [StringLength(255)]
        public string LeaveType { get; set; }

        public short? LeaveCount { get; set; }

        [StringLength(255)]
        public string ApprovalStatus { get; set; }
    }
}
