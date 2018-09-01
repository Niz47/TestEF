namespace TestEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
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
            var dbInit = new DbInitializer();
            // dbInit.Seed(context);


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
    }
}
