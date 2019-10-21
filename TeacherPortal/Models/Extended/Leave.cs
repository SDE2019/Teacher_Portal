using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeacherPortal.Models
{
    [MetadataType(typeof(LeaveAnnotations))]
    public partial class Leave
    {

    }
    public class LeaveAnnotations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveID { get; set; }

        [StringLength(255)]
        public string Id { get; set; }

        [StringLength(255)]
        [Display(Name ="Leave Description")]
        public string LeaveDescription { get; set; }

        [Display(Name = "Temporary Contact")]
        public int? TempContact { get; set; }


        [Display(Name = "Start Date")]
        [Column(TypeName = "smalldatetime")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [Column(TypeName = "smalldatetime")]
        [GreaterThan("StartDate")]
        public DateTime? EndDate { get; set; }

        [StringLength(255)]
        [Display(Name = "Leave Type")]
        public string LeaveType { get; set; }

        [StringLength(255)]
        [Display(Name = "Approval Status")]
        public string ApprovalStatus { get; set; }
    }
}