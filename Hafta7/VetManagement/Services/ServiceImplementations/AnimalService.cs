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
    public class AnimalService : IAnimalService
    {
        private readonly VetDbContext _dbContext;
        public AnimalService(VetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Animal>> GetAllAsync()
        {
            return await _dbContext.Animals.ToListAsync();
        }

        public async Task<Animal> GetAsync(int id)
        {
            var animal = await _dbContext.Animals.FindAsync(id);
            return animal;
        }

        public async Task<Animal> CreateAsync(Animal animal)
        {
            _dbContext.Animals.Add(animal);
            await _dbContext.SaveChangesAsync();
            return animal;
        }
        public async Task UpdateAsync(int id, Animal animal)
        {
            if( id != animal.Id) { throw new Exception("Id not found"); }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalExists(id))
                {
                    throw new Exception($" Cannot find animal by Id: {id} ");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            Animal animal = await _dbContext.Animals.FindAsync(id);

            if(animal == null)
            {
                throw new Exception("Animal cannot found");
            }

            _dbContext.Animals.Remove(animal);
            await _dbContext.SaveChangesAsync();
        }

        private bool AnimalExists(int id)
        {
            return _dbContext.Animals.Any(e => e.Id == id);
        }



    }
}
