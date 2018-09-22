namespace TestEF.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using TestEF.DAL;
    using TestEF.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestEF.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "TestEF.Models.ApplicationDbContext";
        }

        protected override void Seed(TestEF.Models.ApplicationDbContext context)
        {
            CreateRolesandUsers(context);

            //var dbInit = new DbInitializer();
            //dbInit.Seed(context);


            // context.Student.Add(new Student { Name = "Zin Mar", Age = 26 });

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesandUsers(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            try
            {
                // In Startup iam creating first Admin Role and creating a default Admin User    
                if (!roleManager.RoleExists("Admin"))
                {
                    // first we create Admin rool   
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);

                    //Here we create a Admin super user who will maintain the website                  

                    var user = new ApplicationUser();
                    user.UserName = "Administrator";
                    user.Email = "admin@gmail.com";

                    string userPWD = "$Hwe123";

                    var chkUser = UserManager.Create(user, userPWD);

                    //Add default User to Role Admin   
                    if (chkUser.Succeeded)
                    {
                        var result1 = UserManager.AddToRole(user.Id, "Admin");

                    }
                }

                // creating Creating Manager role    
                if (!roleManager.RoleExists("Manager"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Manager";
                    roleManager.Create(role);

                }

                // creating Creating Employee role    
                if (!roleManager.RoleExists("Default User"))
                {
                    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                    role.Name = "Default User";
                    roleManager.Create(role);

                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
