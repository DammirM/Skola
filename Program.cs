using Microsoft.EntityFrameworkCore;
using Skola.Models;
using System.Security.Cryptography.X509Certificates;

namespace Skola
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HighSchoolDbContext Context = new HighSchoolDbContext();


            bool MenuActive = true;

            while (MenuActive == true)
            {
                Console.WriteLine("School Menu:\n1. Teacher and Department\n2. " +
                "StudentCourses\n3. Active Courses\n4. Exit");
                string MenuChoice = Console.ReadLine();


                switch (MenuChoice)
                {

                    case "1":
                        TeacherDepartments(Context);
                        break;
                    case "2":
                        StudentsCourses(Context);
                        break;
                    case "3":
                        ActiveCourses(Context);
                        break;
                    case "4":
                        MenuActive = false;
                        break;
                    default:
                        Console.WriteLine("Choose between 1-4");
                        break;
                }
            }


              static void StudentInfo(HighSchoolDbContext Context)
              {
                Console.Clear();

                var stu = Context.Students.OrderBy(y => y.Id);

                foreach (var item in stu)
                {
                    Console.WriteLine($"ID: {item.Id} Name: {item.Fname} {item.Lname}\nAdress: {item.Adress} Email: {item.Email} Phone: {item.Phone}\n");
                }

                Console.ReadKey();
                Console.Clear();

              }
            

             static void ActiveCourses(HighSchoolDbContext Context)
             {
                Console.Clear();

                // All Active Courses
                var Cou = Context.Classes.Where(x => x.Active == true);

                foreach (var item in Cou)
                {
                    // Showing Active courses
                    Console.WriteLine($"ID: {item.Id} Course: {item.Class1} ({((bool)item.Active ? "Active" : "Inactive")})");
                }
                Console.ReadKey();
                Console.Clear();
            }
            

            static void TeacherDepartments(HighSchoolDbContext Context)
            {
                Console.Clear();

                var staff = Context.staff;

                // making a for count of Staff id
                for (int i = 1; i <= staff.Count(); i++)
                {

                    var staffRole = Context.staff
                        .Where(s => s.Id == i)
                        .Select(s => s.Role).FirstOrDefault();

                    // if the Employee has the StaffID required they will match
                    var Emp = Context.Employees.Where(s => s.Staffid == i);

                    Console.WriteLine($"{Emp.Count()}: {staffRole}\n");
                    foreach (var item in Emp)
                    {
                        Console.WriteLine($"{item.FirstName} {item.LastName}");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();

            }

            static void StudentsCourses(HighSchoolDbContext Context)
            {
                Console.Clear();

                var stu = Context.Students;

                for (int i = 1; i <= stu.Count(); i++)
                {
                    // Many to many Linq to find all courses that each student participates in
                    var student = Context.Students
                    .Include(s => s.StudentClasses)
                    .ThenInclude(sc => sc.Class)
                    .Where(s => s.Id == i)
                    .FirstOrDefault();

                    Console.WriteLine($"Student ID: {student.Id} {student.Fname} {student.Lname}");
                    foreach (var item in student.StudentClasses)
                    {
                        Console.WriteLine($"{item.Class.Class1}");
                    }

                    Console.WriteLine();
                }

                Console.ReadKey();
                Console.Clear();

            }

        }
    }
}