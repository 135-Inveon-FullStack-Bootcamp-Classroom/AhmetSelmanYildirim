using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Data;
using VetManagement.Entity.Entities;
using VetManagement.Services.ServiceAbstracts;

namespace VetManagement.Services.ServiceImplementations
{
    public class PetOwnerService : IPetOwnerService
    {
        private readonly VetDbContext _dbContext;
        public PetOwnerService(VetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<PetOwner>> GetAllAsync()
        {
            return await _dbContext.PetOwners.ToListAsync();
        }

        public async Task<PetOwner> GetAsync(int id)
        {
            var petOwner = await _dbContext.PetOwners.FindAsync(id);
            return petOwner;
        }
        public async Task<PetOwner> CreateAsync(PetOwner petOwner)
        {
            _dbContext.PetOwners.Add(petOwner);
            await _dbContext.SaveChangesAsync();
            return petOwner;
        }
        public async Task UpdateAsync(int id, PetOwner petOwner)
        {
            if (id != petOwner.Id) { throw new Exception("Id not found"); }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetOwnerExists(id))
                {
                    throw new Exception($" Cannot find Pet owner by Id: {id} ");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var petOwner = await _dbContext.PetOwners.FindAsync(id);

            if (petOwner == null)
            {
                throw new Exception("Pet owner cannot found");
            }

            _dbContext.PetOwners.Remove(petOwner);
            await _dbContext.SaveChangesAsync();
        }

        private bool PetOwnerExists(int id)
        {
            return _dbContext.PetOwners.Any(e => e.Id == id);
        }

    }
}
