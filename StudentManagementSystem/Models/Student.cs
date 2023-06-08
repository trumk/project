using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Student : Person
    {
        public float? Grade { get; set; }
        public string Subject { get; }

        public Student(int personId, string personName, string personAddress, DateTime dob, string subject, float? Grade = null)
            : base(personId, personName, personAddress, dob)
        {
            Grade = null;
            Subject = subject;
        }

    }
}
