using Microsoft.EntityFrameworkCore;
using VetManagement.Entity.Entities;

namespace VetManagement.Data
{
    public class VetDbContext : DbContext
    {
        public VetDbContext(DbContextOptions options) : base(options){  }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<ExamRoom> ExamRooms { get; set; }
        public DbSet<ObservationRoom> ObservationRooms { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Veterinarian> Veterinarians { get; set; }


    }
}
