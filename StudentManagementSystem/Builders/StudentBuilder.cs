using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Builders
{
    public interface StudentBuilder
    {
        StudentBuilder SetPersonId(int personId);
        StudentBuilder SetPersonName(string personName);
        StudentBuilder SetPersonAddress(string personAddress);
        StudentBuilder SetDOB(DateTime dob);
        StudentBuilder SetSubject(string subject);
        Student Build();
    }
}
