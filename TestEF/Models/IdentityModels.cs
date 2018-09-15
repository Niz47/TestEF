using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestEF.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Full Name"), Required]
        [StringLength(100)]
        public string FullName { get; set; }

        public bool Gender { get; set; }

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
        public DbSet<Student> Student { get; set; }
        public DbSet<ImageM> Image { get; set; }
        public DbSet<Locations> Locations { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Rename AspNetUsers Table to Users and its field Id to UserId
            modelBuilder.Entity<ApplicationUser>()
                    .ToTable("Users").Property(p => p.Id).HasColumnName("UserId");

            //Rename AspNetUserRoles table to UserRoles
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRoles");

            //Rename AspNetUserLogins table to UserLogins
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins");

            //Rename AspNetUserClaims table to UserClaims and its field Id to UserClaimId
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims").Property(p => p.Id).HasColumnName("UserClaimId");

            //Rename AspNetRoles table to Roles and its field Id to RoleId
            modelBuilder.Entity<IdentityRole>().ToTable("Roles").Property(p => p.Id).HasColumnName("RoleId");
        }
    }
}