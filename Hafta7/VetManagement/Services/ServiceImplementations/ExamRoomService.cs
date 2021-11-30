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
    public class ExamRoomService : IExamRoomService
    {
        private readonly VetDbContext _dbContext;
        public ExamRoomService(VetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ExamRoom>> GetAllAsync()
        {
            return await _dbContext.ExamRooms.ToListAsync();
        }

        public async Task<ExamRoom> GetAsync(int id)
        {
            var examRoom = await _dbContext.ExamRooms.FindAsync(id);
            return examRoom;
        }
        public async Task<ExamRoom> CreateAsync(ExamRoom examRoom)
        {
            _dbContext.ExamRooms.Add(examRoom);
            await _dbContext.SaveChangesAsync();
            return examRoom;
        }
        public async Task UpdateAsync(int id, ExamRoom examRoom)
        {
            if (id != examRoom.Id) { throw new Exception("Id not found"); }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamRoomExists(id))
                {
                    throw new Exception($" Cannot find Exam Room by Id: {id} ");
                }
                else
                {
                    throw;
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            var examRoom = await _dbContext.ExamRooms.FindAsync(id);

            if (examRoom == null)
            {
                throw new Exception("examRoom cannot found");
            }

            _dbContext.ExamRooms.Remove(examRoom);
            await _dbContext.SaveChangesAsync();
        }

        private bool ExamRoomExists(int id)
        {
            return _dbContext.Assistants.Any(e => e.Id == id);
        }


    }
}
