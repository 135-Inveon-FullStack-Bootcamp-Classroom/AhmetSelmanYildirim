using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Entity.Entities;

namespace VetManagement.Services.ServiceAbstracts
{
    public interface IVeterinarianService
    {
        public Task<IEnumerable<Veterinarian>> GetAllAsync();
        public Task<Veterinarian> GetAsync(int id);
        public Task UpdateAsync(int id, Veterinarian veterinarian);
        public Task<Veterinarian> CreateAsync(Veterinarian veterinarian);
        public Task DeleteAsync(int id);
    }
}
