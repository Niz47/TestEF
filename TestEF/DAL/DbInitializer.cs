using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using TestEF.Models;

namespace TestEF.DAL
{
    public class DbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        public DbInitializer()
        {

        }
        public void Seed(ApplicationDbContext context)
        {
            // Student Database Seeding
            var students = new List<Student>
            {
            new Student{Name="Carson",Age=20},
            new Student{Name="Meredith",Age=21},
            new Student{Name="Arturo",Age=23},
            new Student{Name="Gytis",Age=26},
            new Student{Name="Yan",Age=22},
            new Student{Name="Peggy",Age=20},
            new Student{Name="Laura",Age=23},
            new Student{Name="Nino",Age=22}
            };
            students.ForEach(s => context.Student.Add(s));
            context.SaveChanges();

            // create 3 students to seed the database
            context.Student.Add(new Student { ID = 1, Name = "Mark", Age = 20 });
            context.Student.Add(new Student { ID = 2, Name = "Paula", Age = 20 });
            context.Student.Add(new Student { ID = 3, Name = "Tom", Age = 20 });
            context.Student.Add(new Student { ID=4, Name = "Gytis", Age = 26 });
            base.Seed(context);

            // User - Role Database Seeding
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(RoleNames.ROLE_ADMINISTRATOR))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_ADMINISTRATOR));
            }
            if (!roleManager.RoleExists(RoleNames.ROLE_USER))
            {
                var roleresult = roleManager.Create(new IdentityRole(RoleNames.ROLE_USER));
            }

            // Create Admin
            string userName = "admin@gmail.com";
            string password = "$Hwe123";
            ApplicationUser user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    FullName = "Administrator",
                    Email = userName,
                    EmailConfirmed = true,
                    Gender = false
                };
                IdentityResult userResult = userManager.Create(user, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, RoleNames.ROLE_ADMINISTRATOR);
                }
            }

            // Create Test User
            userName = "tester1@gmail.com";
            password = "$Hwe123";
            ApplicationUser testuser = userManager.FindByName(userName);
            if (testuser == null)
            {
                testuser = new ApplicationUser()
                {
                    UserName = userName,
                    FullName = "Tester 1",
                    Email = userName,
                    EmailConfirmed = true,
                    Gender = true
                };
                IdentityResult userResult = userManager.Create(testuser, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(testuser.Id, RoleNames.ROLE_USER);
                }
            }
        }
    }
}