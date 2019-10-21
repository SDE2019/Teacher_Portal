namespace TeacherPortal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TeacherDatabase : DbContext
    {
        public TeacherDatabase()
            : base("name=TeacherDatabase")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Designation> Designations { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Leave> Leaves { get; set; }
        public virtual DbSet<LeaveCount> LeaveCounts { get; set; }
        public virtual DbSet<Prev_Experience> Prev_Experience { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Publication> Publications { get; set; }
        public virtual DbSet<Qualification> Qualifications { get; set; }
        public virtual DbSet<Script> Scripts { get; set; }
        public virtual DbSet<Student_Project> Student_Project { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.Department)
                .HasForeignKey(e => e.Dept_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Designation>()
                .HasMany(e => e.Teachers)
                .WithRequired(e => e.Designation)
                .HasForeignKey(e => e.Designation_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.Events)
                .Map(m => m.ToTable("Teacher_Events").MapLeftKey("Event_Id"));

            modelBuilder.Entity<Project>()
                .HasMany(e => e.Student_Project)
                .WithRequired(e => e.Project)
                .HasForeignKey(e => e.Proj_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Publication>()
                .HasMany(e => e.Teachers)
                .WithMany(e => e.Publications)
                .Map(m => m.ToTable("Teacher_Publication").MapLeftKey("Pub_No").MapRightKey("TID"));

            modelBuilder.Entity<Subject>()
                .HasMany(e => e.Scripts)
                .WithRequired(e => e.Subject)
                .HasForeignKey(e => e.Subj_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Aadhar)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Teacher>()
                .Property(e => e.Phno)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Prev_Experience)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.TID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Projects)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.TID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Qualifications)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.TID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Teacher>()
                .HasMany(e => e.Scripts)
                .WithRequired(e => e.Teacher)
                .HasForeignKey(e => e.TID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Leave>()
                .Property(e => e.LeaveID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
