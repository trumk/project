using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Builders
{
    public interface PersonBuilder
    {
        void SetPersonId(int personId);
        void SetPersonName(string personName);
        void SetPersonAddress(string personAddress);
        void SetDOB(DateTime dob);
        Person Build();
    }
}
