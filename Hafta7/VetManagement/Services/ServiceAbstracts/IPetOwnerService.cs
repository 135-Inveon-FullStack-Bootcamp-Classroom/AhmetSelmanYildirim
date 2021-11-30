using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Entity.Entities;

namespace VetManagement.Services.ServiceAbstracts
{
    public interface IPetOwnerService
    {
        public Task<IEnumerable<PetOwner>> GetAllAsync();
        public Task<PetOwner> GetAsync(int id);
        public Task UpdateAsync(int id, PetOwner petOwner);
        public Task<PetOwner> CreateAsync(PetOwner petOwner);
        public Task DeleteAsync(int id);
    }
}
