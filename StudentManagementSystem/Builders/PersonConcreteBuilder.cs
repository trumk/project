using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Builders
{
    public class PersonConcreteBuilder : PersonBuilder
    {
        private int personId;
        private string personName;
        private string personAddress;
        private DateTime dob;

        public void SetPersonId(int personId)
        {
            this.personId = personId;
        }

        public void SetPersonName(string personName)
        {
            this.personName = personName;
        }

        public void SetPersonAddress(string personAddress)
        {
            this.personAddress = personAddress;
        }

        public void SetDOB(DateTime dob)
        {
            this.dob = dob;
        }

        public Person Build()
        {
            return new Person(personId, personName, personAddress, dob);
        }
    }
}

