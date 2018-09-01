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

        }
    }
}