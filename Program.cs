using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using static System.Console;

namespace College_DBEF
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public long Phone { get; set; }
        public string Clubs { get; set; }
        public string Scholarships { get; set; }
        public virtual List<Class> Classes { get; set; }
    }

    public class Class
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public string Department { get; set; }     
    }

    public class Score
    {
        [Key]
        public int ScoreID { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime Date_Assigned { get; set; }
        public DateTime Date_Due { get; set; }
        public DateTime Date_Submitted { get; set; }
        public int Points_Earned { get; set; }
        public int Points_Possible { get; set; }
        public virtual Class Score_ID { get; set; }
    }
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("CollegeDBEF")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CollegeContext, Migrations.Configuration>());
        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Score> Scores { get; set; }
    }



    class Program
    {
        static void Main(string[] args)
        {

            DateTime date1 = new DateTime(2010, 8, 18);
            DateTime Assigned = new DateTime(2018, 1, 1);
            DateTime Submitted = new DateTime(2018, 2, 2);
            DateTime Due = new DateTime(2018, 3, 3);

            CollegeContext db = new CollegeContext();

            var ClassLadders = new Class
            {
                Title = "Introduction to Ladders!",
                Department = "History",
                Number = 101
            };
            //db.Classes.Add(ClassLadders);
            List<Class> BustersClasses = new List<Class>();
            BustersClasses.Add(ClassLadders);

            Student Buster = new Student
            {
                FName = "Buster",
                LName = "Bluth",
                Address = "123 Sudden Valley",
                City = "Sacramende",
                State = "California",
                Phone = 12345678,
                Zip = 11213,
                Clubs = "Drama",
                Scholarships = "Yes",
                Classes = BustersClasses
                };
                db.Students.Add(Buster);

            var ClassMath = new Class
            {
                Title = "Introduction to Math",
                Department = "Math",
                Number = 102
            };
            List<Class> CarltonsClass = new List<Class>();
            CarltonsClass.Add(ClassMath);

            db.Classes.Add(ClassMath);


            Student Carlton = new Student
                {
                    FName = "Carlton",
                    LName = "Banks",
                    Address = "456 Bellair",
                    City = "Bellair",
                    State = "California",
                    Phone = 13338839,
                    Zip = 33213,
                    Clubs = "Chess",
                    Scholarships = "Yes",
                    Classes = CarltonsClass
                };
                db.Students.Add(Carlton);

            var ClassEnglish = new Class
            {
                Title = "Pre-English English",
                Department = "English",
                Number = 202

            };
            List<Class> BritasClass = new List<Class>();
            BritasClass.Add(ClassEnglish);

            Student Brita = new Student
                {
                    FName = "Brita",
                    LName = "Perry",
                    Address = "43 Euclid",
                    City = "Bellair",
                    State = "Ohio",
                    Phone = 1440114595,
                    Zip = 44213,
                    Clubs = "Math",
                    Scholarships = "Yes",
                    Classes = BritasClass
                };
                db.Students.Add(Brita);

            
                Score scorebook1 = new Score
                {
                    Type = "exam",
                    ScoreID = 1,
                    Date_Assigned = Assigned,
                    Date_Due = Due,
                    Date_Submitted = Submitted,
                    Description = "Very good.",
                    Points_Earned = 89,
                    Points_Possible = 100
                };
            db.Scores.Add(scorebook1);

               

                Score scorebook2 = new Score
                {
                    Type = "test",
                    ScoreID = 2,
                    Date_Assigned = Assigned,
                    Date_Due = Due,
                    Date_Submitted = Submitted,
                    Description = "Not bad!",
                    Points_Earned = 87,
                    Points_Possible = 100

                };
            db.Scores.Add(scorebook2);



                db.Classes.Add(ClassEnglish);

                Score scorebook3 = new Score
                {
                    Type = "take-home",
                    ScoreID = 3,
                    Date_Assigned = Assigned,
                    Date_Due = Due,
                    Date_Submitted = Submitted,
                    Description = "Very Well Written",
                    Points_Earned = 97,
                    Points_Possible = 100

                };
            db.Scores.Add(scorebook3);


            db.SaveChanges();

                var query = from student in db.Students
                            orderby student.FName
                            select student;

                foreach (var student in query)
                {
                    WriteLine($"The student {student.LName}, {student.FName} lives at {student.Address}");


                    foreach (Class classes in student.Classes)
                    {
                        WriteLine($"--Title: {classes.Title}");
                        WriteLine($"--Department: {classes.Department}");
                        WriteLine($"--Class Number: {classes.Number}");
                    }
                    WriteLine("Press a key to exit...");
                    ReadKey();
                }

             
            }
        }
    }