using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SchoolManagementSoft.Models.UserDBModel;

namespace SchoolManagementSoft.Models
{
    public enum Gender { Male, Female }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        #region

        //add new property in existing users table
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return (FirstName + " " + LastName); }
        }
        public Gender Gender { get; set; }

        public string BranchCode { get; set; }
        public int ZoneID { get; set; }

        #endregion
    }


    //Add Role



    #region

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string name) : base(name) { }

        public string Description { get; set; }
    }
    #endregion

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            //   : base("DbConnection", throwIfV1Schema: false)
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //Today Class
        public DbSet<CommonDataForAll.Designation> Designations { get; set; }
        public DbSet<CommonDataForAll.Education> Educations { get; set; }
        public DbSet<CommonDataForAll.Group> Groups { get; set; }
        public DbSet<CommonDataForAll.Class> Classes { get; set; }
        public DbSet<CommonDataForAll.ClassSection> ClassSections { get; set; }
        public DbSet<TeacherData.TeacherProfile> TeacherProfiles { get; set; }
        public DbSet<Admission.AdmissionFrom> admissionFroms { get; set; }
        public DbSet<Admission.AdmissionCost> admissionCosts { get; set; }
        public DbSet<StudenData.StudentProfile> StudentProfiles { get; set; }

        // Previous Class
        public DbSet<UserDBModel.Religion> Religions { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Zone> Zones { get; set; }




        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        //}

    }
}