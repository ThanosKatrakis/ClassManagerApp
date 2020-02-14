using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateSchoolThanosKatrakis
{
    class Trainer
    {
        // Fields & Properties
        public int TrainerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        // Constructor
        public Trainer(int trainerID, string firstName, string lastName, string subject)
        {
            TrainerID = trainerID;
            FirstName = firstName;
            LastName = lastName;
            Subject = subject;
        }

        // Methods
        public void Output()
        {
            Console.WriteLine("Id: " + TrainerID);
            Console.WriteLine("First Name: " + FirstName);
            Console.WriteLine("Last Name: " + LastName);
            Console.WriteLine("Subject: " + Subject);
            Console.WriteLine(" ");
        }
    }
}
