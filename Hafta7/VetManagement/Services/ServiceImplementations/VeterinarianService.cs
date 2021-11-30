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
    public class VeterinarianService : IVeterinarianService
    {
        private readonly VetDbContext _dbContext;
        public VeterinarianService(VetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Veterinarian>> GetAllAsync()
        {
            return await _dbContext.Veterinarians.ToListAsync();
        }

        public async Task<Veterinarian> GetAsync(int id)
        {
            var veterinarian = await _dbContext.Veterinarians.FindAsync(id);
            return veterinarian;
        }
        public async Task<Veterinarian> CreateAsync(Veterinarian veterinarian)
        {
            _dbContext.Veterinarians.Add(veterinarian);
            await _dbContext.SaveChangesAsync();
            return veterinarian;
        }
        public async Task UpdateAsync(int id, Veterinarian veterinarian)
        {
            if (id != veterinarian.Id) { throw new Exception("Id not found"); }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarianExists(id))
                {
                    throw new Exception($" Cannot find veterinarian by Id: {id} ");
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            var veterinarian = await _dbContext.Veterinarians.FindAsync(id);

            if (veterinarian == null)
            {
                throw new Exception("Veterinarian cannot found");
            }

            _dbContext.Veterinarians.Remove(veterinarian);
            await _dbContext.SaveChangesAsync();
        }
        private bool VeterinarianExists(int id)
        {
            return _dbContext.Assistants.Any(e => e.Id == id);
        }
    }
}
