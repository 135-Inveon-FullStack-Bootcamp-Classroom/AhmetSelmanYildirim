using System.Collections.Generic;
using System.Threading.Tasks;
using VetManagement.Entity.Entities;

namespace VetManagement.Services.ServiceAbstracts
{
    public interface IAssistantService
    {
        public Task<IEnumerable<Assistant>> GetAllAsync();
        public Task<Assistant> GetAsync(int id);
        public Task UpdateAsync(int id, Assistant assistant);
        public Task<Assistant> CreateAsync(Assistant assistant);
        public Task DeleteAsync(int id);
    }
}
