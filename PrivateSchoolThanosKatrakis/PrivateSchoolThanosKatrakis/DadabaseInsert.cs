using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace PrivateSchoolThanosKatrakis
{
    class DadabaseInsert
    {
        public static string conString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public static void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("\t~~~ INSERT DATA ~~~");
            Console.WriteLine("\t~~~~~~~~~~~~~~~~~~~");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("That was all the date in our database.");
            Console.WriteLine("");
            Console.WriteLine("Press 1 to exit the program.");
            Console.WriteLine("Press 2 to insert a student.");
            Console.WriteLine("Press 3 to insert a trainer.");
            Console.WriteLine("Press 4 to insert an assignment.");
            Console.WriteLine("Press 5 to insert a course.");
            Console.WriteLine("Press 6 to insert a student in a course.");
            Console.WriteLine("Press 7 to insert a trainer in a course.");
            Console.WriteLine("Press 8 to insert an assignment in a student and in a course.");
            string answer = Console.ReadLine();

            if (answer == "1") { Environment.Exit(0); }
            else if (answer == "2") { studentInsertionPrint(); }
            else if (answer == "3") { trainerInsertionPrint(); }
            else if (answer == "4") { assignmentInsertionPrint(); }
            else if (answer == "5") { courseInsertionPrint(); }
            else if (answer == "6") { studentCourseInsertionPrint(); }
            else if (answer == "7") { trainerCourseInsertionPrint(); }
            else if (answer == "8") { AssignmentStudentCoursePrint(); }
        }

        // ----------StudentInsertion----------
        public static void studentInsertionPrint()
        {
            Console.WriteLine("Give students first name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Give students last name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Give tuition fees");
            int tuitionFees = int.Parse(Console.ReadLine());

            Console.WriteLine("Give date of birth in form YYYY-MM-DD");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());

            DadabaseInsert.Insertstudent(firstName, lastName, tuitionFees, birthDate);
        }

        public static void Insertstudent(string fn, string ln, int tf, DateTime bd)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Student (FirstName, LastName, TuitionFees, DateOfBirth) VALUES(@FirstName, @LastName, @TuitionFees, @DateOfBirth)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FirstName", fn);
            cmd.Parameters.AddWithValue("@LastName", ln);
            cmd.Parameters.AddWithValue("@TuitionFees", tf);
            cmd.Parameters.AddWithValue("@DateOfBirth", bd);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR. Something went wrong" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }

        // ----------TrainerInsertion----------
        public static void trainerInsertionPrint()
        {
            Console.WriteLine("Give trainers first name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Give trainers last name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Give trainers subject");
            string subject = Console.ReadLine();

            DadabaseInsert.InsertsTrainer(firstName, lastName, subject);
        }

        public static void InsertsTrainer(string fn, string ln, string su)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Trainer (FirstName, LastName, Subject) VALUES(@FirstName, @LastName, @Subject)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@FirstName", fn);
            cmd.Parameters.AddWithValue("@LastName", ln);
            cmd.Parameters.AddWithValue("@Subject", su);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Trainer Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR. Something went wrong" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }

        // ----------AssignmentInsertion----------
        public static void assignmentInsertionPrint()
        {
            Console.WriteLine("Give assignment title");
            string title = Console.ReadLine();

            Console.WriteLine("Give assignment description");
            string description = Console.ReadLine();

            Console.WriteLine("Give submission date in form YYYY-MM-DD");
            DateTime submissionDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Give oral mark");
            int oralMark = int.Parse(Console.ReadLine());

            Console.WriteLine("Give total mark");
            int totalMark = int.Parse(Console.ReadLine());

            DadabaseInsert.InsertAssignment(title, description, submissionDate, oralMark, totalMark);
        }

        public static void InsertAssignment(string ti, string de, DateTime sd, int om, int tm)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Assignment (Title, Discription, SubmissionDate, OralMark, TotalMark) VALUES(@Title, @Discription, @SubmissionDate, @OralMark, @TotalMark)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", ti);
            cmd.Parameters.AddWithValue("@Discription", de);
            cmd.Parameters.AddWithValue("@SubmissionDate", sd);
            cmd.Parameters.AddWithValue("@OralMark", om);
            cmd.Parameters.AddWithValue("@TotalMark", tm);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Assignment Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR. Something went wrong" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }

        // ----------CourseInsertion----------
        public static void courseInsertionPrint()
        {
            Console.WriteLine("Give course title");
            string title = Console.ReadLine();

            Console.WriteLine("Give course stream");
            string stream = Console.ReadLine();

            Console.WriteLine("Give course type");
            string type = Console.ReadLine();

            Console.WriteLine("Give course start date in form YYYY-MM-DD");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("Give course end date in form YYYY-MM-DD");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());


            DadabaseInsert.InsertCourse(title, stream, type, startDate, endDate);
        }

        public static void InsertCourse(string ti, string st, string ty, DateTime sd, DateTime ed)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO Course (Title, Stream, Type, StartDate, EndDate) VALUES(@Title, @Stream, @Type, @StartDate, @EndDate)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@Title", ti);
            cmd.Parameters.AddWithValue("@Stream", st);
            cmd.Parameters.AddWithValue("@Type", ty);
            cmd.Parameters.AddWithValue("@StartDate", sd);
            cmd.Parameters.AddWithValue("@EndDate", ed);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Course Inserted Successfully");
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR. Something went wrong" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }

        // ----------StudentPerCourseInsertion----------
        public static void studentCourseInsertionPrint()
        {
            
            Console.WriteLine("Give an existing student Id from the above students");
            int studentID = int.Parse(Console.ReadLine());

            Console.WriteLine("Give an existing course Id from the above courses");
            int courseID = int.Parse(Console.ReadLine());

            Console.WriteLine("Give an existing assignment Id from the above assignments");
            int assignmentID = int.Parse(Console.ReadLine());

            DadabaseInsert.InsertstudentCourse(studentID, courseID, assignmentID);
        }

        public static void InsertstudentCourse(int sid, int cid, int aid)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO AssignmentPerCoursePerStudent (StudentID, CourseID, AssignmentID) VALUES(@StudentID, @CourseID, @AssignmentID)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@StudentID", sid);
            cmd.Parameters.AddWithValue("@CourseID", cid);
            cmd.Parameters.AddWithValue("@AssignmentID", aid);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student Inserted Successfully on the course");
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR. Something went wrong" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }

        // ----------TrainerPerCourseInsertion----------
        public static void trainerCourseInsertionPrint()
        {

            Console.WriteLine("Give an existing trainer Id from the above trainers");
            int trainerID = int.Parse(Console.ReadLine());

            Console.WriteLine("Give an existing course Id from the above courses");
            int courseID = int.Parse(Console.ReadLine());

            DadabaseInsert.InsertTrainerCourse(trainerID, courseID);
        }

        public static void InsertTrainerCourse(int tid, int cid)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO TrainerPerCourse (TrainerID, CourseID) VALUES(@TrainerID, @CourseID)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@TrainerID", tid);
            cmd.Parameters.AddWithValue("@CourseID", cid);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Trainer Inserted Successfully on the course");
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR. Something went wrong" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }

        // ----------StudentPerCourseInsertion----------
        public static void AssignmentStudentCoursePrint()
        {
            Console.WriteLine("Give an existing assignment Id from the above assignments");
            int assignmentID = int.Parse(Console.ReadLine());

            Console.WriteLine("Give an existing student Id from the above students");
            int studentID = int.Parse(Console.ReadLine());

            Console.WriteLine("Give an existing course Id from the above courses");
            int courseID = int.Parse(Console.ReadLine());

            DadabaseInsert.InsertstudentCourse(assignmentID, studentID, courseID);
        }

        public static void InsertAssignmentPerstudentCourse(int aid, int sid, int cid)
        {
            SqlConnection con = new SqlConnection(conString);

            string query = "INSERT INTO AssignmentPerCoursePerStudent (AssignmentID, StudentID, CourseID) VALUES(@AssignmentID, @StudentID, @CourseID)";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@AssignmentID", aid);
            cmd.Parameters.AddWithValue("@StudentID", sid);
            cmd.Parameters.AddWithValue("@CourseID", cid);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Assignment Inserted Successfully on student and course");
            }
            catch (SqlException e)
            {
                Console.WriteLine("ERROR. Something went wrong" + e.ToString());
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
        }
    }
}
