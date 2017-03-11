using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace FestMVC.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public virtual ICollection<Enrollment> Ennrollments { get; set; }
        public virtual ICollection<FestivalEnrollment> FestivalEnnrollments { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<FestMVC.Models.Festival> Festivals { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.Room> Rooms { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.Instructor> Instructors { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.Enrollment> Enrollments { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.FestivalManager> FestivalManagers { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.Event> Events { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.EventImage> EventImages { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.Arena> Arenas { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.FestivalEnrollment> FestivalEnrollments { get; set; }

        public System.Data.Entity.DbSet<FestMVC.Models.Location> Locations { get; set; }

        //public System.Data.Entity.DbSet<FestMVC.Models.Increment> Incrments { get; set; }

        //public System.Data.Entity.DbSet<FestMVC.Models.ApplicationUser> ApplicationUsers { get; set; }
    }
}