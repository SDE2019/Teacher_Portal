using Foolproof;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

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
        [Display(Name = "Leave Description")]
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
    public class LeaveAndDesg
    {
        public List<Leave> leaves { get; set; }
        public string desg { get; set; }
    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public string Argument { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;
            var keyValue = string.Format("{0}:{1}", Name, Argument);
            var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

            if (value != null)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                isValidName = true;
            }

            return isValidName;
        }
    }
}