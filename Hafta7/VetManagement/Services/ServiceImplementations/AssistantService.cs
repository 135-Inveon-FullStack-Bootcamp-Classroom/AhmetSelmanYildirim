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
    public class AssistantService : IAssistantService
    {
        private readonly VetDbContext _dbContext;
        public AssistantService(VetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Assistant>> GetAllAsync()
        {
            return await _dbContext.Assistants.ToListAsync();
        }

        public async Task<Assistant> GetAsync(int id)
        {
            var assistant = await _dbContext.Assistants.FindAsync(id);
            return assistant;
        }

        public async Task<Assistant> CreateAsync(Assistant assistant)
        {
            _dbContext.Assistants.Add(assistant);
            await _dbContext.SaveChangesAsync();
            return assistant;
        }

        public async Task UpdateAsync(int id, Assistant assistant)
        {
            if (id != assistant.Id) { throw new Exception("Id not found"); }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssistantExists(id))
                {
                    throw new Exception($" Cannot find assistant by Id: {id} ");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var assistant = await _dbContext.Assistants.FindAsync(id);

            if (assistant == null)
            {
                throw new Exception("Assistant cannot found");
            }

            _dbContext.Assistants.Remove(assistant);
            await _dbContext.SaveChangesAsync();
        }

        private bool AssistantExists(int id)
        {
            return _dbContext.Assistants.Any(e => e.Id == id);
        }
    }
}
