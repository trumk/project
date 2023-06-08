using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int NumLesson { get; set; }

        public Subject(int subjectId, string subjectName, int numLesson)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
            NumLesson = numLesson;
        }
    }
}
