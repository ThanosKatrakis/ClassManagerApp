using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace PrivateSchoolThanosKatrakis
{
    class Prints
    {
        public static string conString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public static void PrintAllStudents()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                List<Student> temp = new List<Student>();

                string querystring = "Select * from Student";
                con.Open();

                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ STUDENTS LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Student s = new Student(
                        Convert.ToInt32(reader["StudentID"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        Convert.ToInt32(reader["TuitionFees"]),
                        Convert.ToDateTime(reader["DateOfBirth"])
                        );
                    temp.Add(s);
                }

                foreach (var item in temp)
                {
                    item.Output();
                }
            }
        }

        public static void PrintAllTrainers()
        {
            List<Trainer> temp = new List<Trainer>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "Select * from Trainer";
                con.Open();

                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ TRAINERS LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Trainer t = new Trainer(
                        Convert.ToInt32(reader["TrainerID"]),
                        reader["FirstName"].ToString(),
                        reader["LastName"].ToString(),
                        reader["Subject"].ToString()
                        );
                    temp.Add(t);
                }

                foreach (var item in temp)
                {
                    item.Output();
                }
            }
        }

        public static void PrintAllAssignments()
        {
            List<Assignment> temp = new List<Assignment>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "Select * from Assignment";
                con.Open();

                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ ASSIGNMENT LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Assignment a = new Assignment(
                        Convert.ToInt32(reader["AssignmentID"]),
                        reader["Title"].ToString(),
                        reader["Discription"].ToString(),
                        Convert.ToDateTime(reader["SubmissionDate"]),
                        Convert.ToInt32(reader["OralMark"]),
                        Convert.ToInt32(reader["TotalMark"])
                        );
                    temp.Add(a);
                }

                foreach (var item in temp)
                {
                    item.Output();
                }
            }
        }

        public static void PrintAllCourses()
        {
            List<Course> temp = new List<Course>();

            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "Select * from Course";
                con.Open();

                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ COURSE LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Course c = new Course(
                        Convert.ToInt32(reader["CourseID"]),
                        reader["Title"].ToString(),
                        reader["Stream"].ToString(),
                        reader["Type"].ToString(),
                        Convert.ToDateTime(reader["StartDate"]),
                        Convert.ToDateTime(reader["EndDate"])
                        );

                    temp.Add(c);
                }

                foreach (var item in temp)
                {
                    item.Output();
                }
            }
        }

        public static void PrintStudentCourse()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "SELECT FirstName, LastName, Title, Type " +
                                      "FROM Student " +
                                      "INNER JOIN AssignmentPerCoursePerStudent ON Student.StudentID = AssignmentPerCoursePerStudent.StudentID " +
                                      "INNER JOIN Course ON AssignmentPerCoursePerStudent.CourseID = Course.CourseID";

                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ STUDENTS PER COURSE LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Console.WriteLine("First Name: " + reader[0].ToString());
                    Console.WriteLine("Last Name: " + reader[1].ToString());
                    Console.WriteLine("Course Title: " + reader[2].ToString());
                    Console.WriteLine("Course Type: " + reader[3].ToString());
                    Console.WriteLine(" ");
                }
            }

        }

        public static void PrintTrainerCourse()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "SELECT FirstName, LastName, Subject, Title, Type " +
                                      "FROM Trainer " +
                                      "INNER JOIN TrainerPerCourse ON Trainer.TrainerID = TrainerPerCourse.TrainerID " +
                                      "INNER JOIN Course ON TrainerPerCourse.CourseID = Course.CourseID";

                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ TRAINER PER COURSE LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Console.WriteLine("First Name: " + reader[0].ToString());
                    Console.WriteLine("Last Name: " + reader[1].ToString());
                    Console.WriteLine("Subject: " + reader[2].ToString());
                    Console.WriteLine("Course Title: " + reader[3].ToString());
                    Console.WriteLine("Course Type: " + reader[4].ToString());
                    Console.WriteLine(" ");
                }
            }
        }

        public static void PrintAssignmentCourse()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "SELECT DISTINCT Assignment.Title, Discription, Course.Title, Course.Type " +
                                      "FROM Assignment " +
                                      "INNER JOIN AssignmentPerCoursePerStudent ON Assignment.AssignmentID = AssignmentPerCoursePerStudent.AssignmentID " +
                                      "INNER JOIN Course ON AssignmentPerCoursePerStudent.CourseID = Course.CourseID";

                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ ASSIGNMENT PER COURSE LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Console.WriteLine("Title: " + reader[0].ToString());
                    Console.WriteLine("Discription: " + reader[1].ToString());
                    Console.WriteLine("Course Title: " + reader[2].ToString());
                    Console.WriteLine("Course Type: " + reader[3].ToString());
                    Console.WriteLine(" ");
                }
            }
        }

        public static void PrintAssignmentCourseStudent()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "SELECT DISTINCT Assignment.Title, Assignment.Discription, Course.Title, Course.Type, Student.FirstName, Student.LastName " +
                                      "FROM Assignment " +
                                      "INNER JOIN AssignmentPerCoursePerStudent ON Assignment.AssignmentID = AssignmentPerCoursePerStudent.AssignmentID " +
                                      "INNER JOIN Course ON AssignmentPerCoursePerStudent.CourseID = Course.CourseID " +
                                      "INNER JOIN Student on AssignmentPerCoursePerStudent.StudentID = Student.StudentID";

                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ ASSIGNMENT PER COURSE PER STUDENT LIST ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Console.WriteLine("Title: " + reader[0].ToString());
                    Console.WriteLine("Discription: " + reader[1].ToString());
                    Console.WriteLine("Course Title: " + reader[2].ToString());
                    Console.WriteLine("Course Type: " + reader[3].ToString());
                    Console.WriteLine("First Name: " + reader[4].ToString());
                    Console.WriteLine("Last Name: " + reader[5].ToString());
                    Console.WriteLine(" ");
                }
            }
        }

        public static void StudentMoreThanOneCourse()
        {
            using (SqlConnection con = new SqlConnection(conString))
            {
                string querystring = "select DISTINCT Student.StudentID, FirstName, LastName, DateOfBirth " +
                    "from Student " +
                    "inner join AssignmentPerCoursePerStudent on Student.StudentID = AssignmentPerCoursePerStudent.StudentID " +
                    "inner join course on AssignmentPerCoursePerStudent.CourseID = Course.CourseID " +
                    "group by FirstName, LastName, Student.StudentID, DateOfBirth " +
                    "having count(DISTINCT AssignmentPerCoursePerStudent.CourseID) > 1";

                con.Open();
                SqlCommand cmd = new SqlCommand(querystring, con);
                SqlDataReader reader = cmd.ExecuteReader();

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\t~~~ STUDENTS WITH MORE THAN ONE COURSE ~~~");
                Console.ForegroundColor = ConsoleColor.White;

                while (reader.Read())
                {
                    Console.WriteLine("Student ID: " + reader[0].ToString());
                    Console.WriteLine("First Name: " + reader[1].ToString());
                    Console.WriteLine("Last Name: " + reader[2].ToString());
                    Console.WriteLine("Date Of Birth: " + reader[3].ToString());
                    Console.WriteLine(" ");
                }
            }
        }
    }
}
