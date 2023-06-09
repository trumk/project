using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Student : Person
    {
        private static int nextId = 1; 

        public int Id { get; } 

        public float? Grade { get; set; }
        public string Subject { get; }

        public Student(string personName, string personAddress, DateTime dob, string subject, float? grade = null)
            : base(nextId, personName, personAddress, dob)
        {
            Id = nextId;
            Grade = grade;
            Subject = subject;
        }

        public static int GetNextId()
        {
            return nextId;
        }

        public static void IncrementNextId()
        {
            nextId += 1; ;
        }
    }
}
