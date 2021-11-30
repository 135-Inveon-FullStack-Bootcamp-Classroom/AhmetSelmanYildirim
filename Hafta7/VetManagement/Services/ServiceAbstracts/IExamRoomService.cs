using System.Collections.Generic;
using System.Threading.Tasks;
using VetManagement.Entity.Entities;

namespace VetManagement.Services.ServiceAbstracts
{
    public interface IExamRoomService
    {
        public Task<IEnumerable<ExamRoom>> GetAllAsync();
        public Task<ExamRoom> GetAsync(int id);
        public Task UpdateAsync(int id, ExamRoom examRoom);
        public Task<ExamRoom> CreateAsync(ExamRoom examRoom);
        public Task DeleteAsync(int id);
    }
}
