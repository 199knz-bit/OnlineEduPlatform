using OnlineEduPlatform.Models;
using System.Runtime.CompilerServices;

namespace OnlineEduPlatform.Data
{
    public class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Teachers.Any())
                return;

            var teacher1 = new Teacher { Name = "Иван Петров", Email = "pivan@example.com" };
            var teacher2 = new Teacher { Name = "Мария Иванова", Email = "imaria@example.com" };
            var teacher3 = new Teacher { Name = "Александър Соколов", Email = "saleksandar@example.com" };
            db.Teachers.AddRange(teacher1, teacher2, teacher3);
            db.SaveChanges();

            var course1 = new Course { Name = "Основи на C#", TeacherId = teacher1.Id };
            var course2 = new Course { Name = "Софтуерни технологии", TeacherId = teacher2.Id };
            db.Courses.AddRange(course1, course2);
            db.SaveChanges();

            var student1 = new Student { Name = "Георги Димитров", Email = "dgeorgi@example.com" };
            var student2 = new Student { Name = "Елена Колева", Email = "kelena@example.com" };
            var student3 = new Student { Name = "Димитър Петров", Email = "pmitko@example.com" };
            var student4 = new Student { Name = "Петър Петков", Email = "ppetar@example.com" };
            var student5 = new Student { Name = "Боян Василев", Email = "vboian@example.com" };
            db.Students.AddRange(student1, student2);
            db.SaveChanges();

            course1.Students.Add(student1);
            course1.Students.Add(student2);
            course2.Students.Add(student4);
            course2.Students.Add(student3);
            course2.Students.Add(student5);
            db.SaveChanges();
        }
    }
}
