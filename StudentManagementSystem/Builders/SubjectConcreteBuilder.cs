using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Builders
{
    public class SubjectConcreteBuilder : SubjectBuilder
    {
        private int subjectId;
        private string subjectName;
        private int numLesson;

        public SubjectBuilder SetSubjectId(int subjectId)
        {
            this.subjectId = subjectId;
            return this;
        }

        public SubjectBuilder SetSubjectName(string subjectName)
        {
            this.subjectName = subjectName;
            return this;
        }

        public SubjectBuilder SetNumLesson(int numLesson)
        {
            this.numLesson = numLesson;
            return this;
        }

        public Subject Build()
        {
            return new Subject(subjectName, numLesson);
        }
    }
}
