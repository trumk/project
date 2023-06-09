using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Subject
    {
        private static int nextId = 1;
        public int SubjectId { get; }
        public string SubjectName { get; set; }
        public int NumLesson { get; set; }

        public Subject(string subjectName, int numLesson)
        {
            SubjectId = nextId++;
            SubjectName = subjectName;
            NumLesson = numLesson;
        }
    }

}
