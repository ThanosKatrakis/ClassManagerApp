using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolThanosKatrakis
{
    class Assignment
    {
        // Fields & Properties
        public int AssignmentID { get; set; }
        public string Title { get; set; }
        public string Discription { get; set; }
        public DateTime SubmissionDate { get; set; } = new DateTime();
        public int OralMark { get; set; }
        public int TotalMark { get; set; }

        // Constructor
        public Assignment(int assignmentID, string title, string discription, DateTime submissionDate, int oralMark, int totalMark)
        {
            AssignmentID = assignmentID;
            Title = title;
            Discription = discription;
            SubmissionDate = submissionDate;
            OralMark = oralMark;
            TotalMark = totalMark;
        }

        // Methods
        public void Output()
        {
            Console.WriteLine("Id: " + AssignmentID);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Discription: " + Discription);
            Console.WriteLine("Submission Date: " + SubmissionDate);
            Console.WriteLine("Oral Mark: " + OralMark);
            Console.WriteLine("Total Mark: " + TotalMark);
            Console.WriteLine(" ");
        }
    }
}
