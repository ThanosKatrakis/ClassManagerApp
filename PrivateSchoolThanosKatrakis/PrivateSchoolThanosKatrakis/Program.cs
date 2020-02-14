using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace PrivateSchoolThanosKatrakis
{
    class Program
    {
        static void Main(string[] args)
        {
            Prints.PrintAllStudents();
            Prints.PrintAllTrainers();
            Prints.PrintAllAssignments();
            Prints.PrintAllCourses();
            Prints.PrintStudentCourse();
            Prints.PrintTrainerCourse();
            Prints.PrintAssignmentCourse();
            Prints.PrintAssignmentCourseStudent();
            Prints.StudentMoreThanOneCourse();

            DadabaseInsert.Menu();

            Console.ReadKey();
        }
    }
}