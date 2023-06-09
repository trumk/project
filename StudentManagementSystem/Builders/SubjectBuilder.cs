using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Builders
{
    public interface SubjectBuilder
    {
        SubjectBuilder SetSubjectId(int subjectId);
        SubjectBuilder SetSubjectName(string subjectName);
        SubjectBuilder SetNumLesson(int numLesson);
        Subject Build();
    }
}
