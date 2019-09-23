namespace TeacherPortal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Teacher")]
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            Prev_Experience = new HashSet<Prev_Experience>();
            Projects = new HashSet<Project>();
            Qualifications = new HashSet<Qualification>();
            Scripts = new HashSet<Script>();
            Events = new HashSet<Event>();
            Publications = new HashSet<Publication>();
        }

        [StringLength(255)]
        public string Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public byte[] Photo { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        public int Designation_Id { get; set; }

        [StringLength(10)]
        public string Pan { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Aadhar { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? Phno { get; set; }

        public byte[] Fingerprint { get; set; }

        public int Dept_Id { get; set; }

        public virtual Department Department { get; set; }

        public virtual Designation Designation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prev_Experience> Prev_Experience { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Project> Projects { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Qualification> Qualifications { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Script> Scripts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Event> Events { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
