using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolThanosKatrakis
{
    class Course
    {
        // Fields & Properties
        public int CourseID { get; set; }
        public string Title { get; set; }
        public string Stream { get; set; }
        public string Type { get; set; }
        public DateTime StartDate { get; set; } = new DateTime();
        public DateTime EndDate { get; set; } = new DateTime();

        // Constructor
        public Course(int courseID, string title, string stream, string type, DateTime startDate, DateTime endDate)
        {
            CourseID = courseID;
            Title = title;
            Stream = stream;
            Type = type;
            StartDate = startDate;
            EndDate = endDate;
        }

        // Methods
        public void Output()
        {
            Console.WriteLine("Id: " + CourseID);
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Stream: " + Stream);
            Console.WriteLine("Type: " + Type);
            Console.WriteLine("Start Date: " + StartDate);
            Console.WriteLine("Ent Date: " + EndDate);
            Console.WriteLine(" ");
        }
    }
}
