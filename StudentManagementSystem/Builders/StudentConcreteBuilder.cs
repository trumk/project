using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Builders
{
    public class StudentConcreteBuilder : StudentBuilder
    {
        private int personId;
        private string personName;
        private string personAddress;
        private DateTime dob;
        private string subject;
        private float grade;

        public StudentBuilder SetPersonId(int personId)
        {
            this.personId = personId;
            return this;
        }

        public StudentBuilder SetPersonName(string personName)
        {
            this.personName = personName;
            return this;
        }

        public StudentBuilder SetPersonAddress(string personAddress)
        {
            this.personAddress = personAddress;
            return this;
        }

        public StudentBuilder SetDOB(DateTime dob)
        {
            this.dob = dob;
            return this;
        }

        public StudentBuilder SetSubject(string subject)
        {
            this.subject = subject;
            return this;
        }

        public StudentBuilder SetGrade(float grade)
        {
            this.grade = grade;
            return this;
        }

        public Student Build()
        {
            return new Student(personName, personAddress, dob, subject);
        }
    }
}
