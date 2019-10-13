namespace TeacherPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Microsoft.AspNet.Identity;

    [Table("Leave")]
    public partial class Leave
    {
        [Key]
        [Display(Name = "ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LeaveID { get; set; }

        [StringLength(255)]
        public string Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Reason")]
        public string LeaveDescription { get; set; }

        [Display(Name = "Temporary Contact")]
        public int? TempContact { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; }

        [StringLength(255)]
        [Display(Name = "Nature of Leave")]
        public string LeaveType { get; set; }

        [Display(Name = "Leave Count")]
        public short? LeaveCount { get; set; }

        [StringLength(255)]
        [Display(Name = "Approval Status")]
        public string ApprovalStatus { get; set; }
    }
}
