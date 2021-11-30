using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Entity.EntityBases;

namespace VetManagement.Entity.Entities
{
    public class Animal : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Kind { get; set; }
        public int OwnerId { get; set; }
        public PetOwner Owner { get; set; }

    }
}
