using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetManagement.Entity.EntityBases
{
    public abstract class Person
    {
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
