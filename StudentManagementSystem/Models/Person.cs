using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Person
    {
        private int personId;
        private string personName;
        private string personAddress;
        private DateTime dOb;

        public Person(int personId, string personName, string personAddress, DateTime dOb)
        {
            this.personId = personId;
            this.personName = personName;
            this.personAddress = personAddress;
            this.dOb = dOb;
        }
    }
}
