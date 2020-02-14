using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolThanosKatrakis
{
    class Student
    {
        // Fields & Properties
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TuitionFees { get; set; }
        public DateTime DateOfBirth { get; set; } = new DateTime();

        // Constructor
        public Student(int studentID, string firstName, string lastName, int tuitionFees, DateTime dateOfBirth)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            TuitionFees = tuitionFees;
            DateOfBirth = dateOfBirth;
        }

        // Methods
        public void Output()
        {
            Console.WriteLine("Id: " + StudentID);
            Console.WriteLine("First Name: " + FirstName);
            Console.WriteLine("Last Name: " + LastName);
            Console.WriteLine("Tuition Fees: " + TuitionFees);
            Console.WriteLine("Date Of Birth: " + DateOfBirth);
            Console.WriteLine(" ");
        }
    }
}
