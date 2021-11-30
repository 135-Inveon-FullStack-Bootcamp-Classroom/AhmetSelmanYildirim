using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Entity.EntityBases;

namespace VetManagement.Entity.Entities
{
    public class ObservationRoom : Room, IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
