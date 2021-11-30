using System.Collections.Generic;
using System.Threading.Tasks;
using VetManagement.Entity.Entities;

namespace VetManagement.Services.ServiceAbstracts
{
    public interface IAnimalService
    {
        public Task<IEnumerable<Animal>> GetAllAsync();
        public Task<Animal> GetAsync(int id);
        public Task UpdateAsync(int id, Animal animal);
        public Task<Animal> CreateAsync(Animal animal);
        public Task DeleteAsync(int id);
    }
}
