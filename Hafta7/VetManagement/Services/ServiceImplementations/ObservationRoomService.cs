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
    public class ObservationRoomService : IObservationRoomService
    {
        private readonly VetDbContext _dbContext;
        public ObservationRoomService(VetDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<ObservationRoom>> GetAllAsync()
        {
            return await _dbContext.ObservationRooms.ToListAsync();
        }

        public async Task<ObservationRoom> GetAsync(int id)
        {
            var observationRoom = await _dbContext.ObservationRooms.FindAsync(id);
            return observationRoom;
        }
        public async Task<ObservationRoom> CreateAsync(ObservationRoom observationRoom)
        {
            _dbContext.ObservationRooms.Add(observationRoom);
            await _dbContext.SaveChangesAsync();
            return observationRoom;
        }
        public async Task UpdateAsync(int id, ObservationRoom observationRoom)
        {
            if (id != observationRoom.Id) { throw new Exception("Id not found"); }
            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObservationRoomExists(id))
                {
                    throw new Exception($" Cannot find Observation Room by Id: {id} ");
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task DeleteAsync(int id)
        {
            var observationRoom = await _dbContext.ObservationRooms.FindAsync(id);

            if (observationRoom == null)
            {
                throw new Exception("examRoom cannot found");
            }

            _dbContext.ObservationRooms.Remove(observationRoom);
            await _dbContext.SaveChangesAsync();
        }

        private bool ObservationRoomExists(int id)
        {
            return _dbContext.Assistants.Any(e => e.Id == id);
        }


    }
}
