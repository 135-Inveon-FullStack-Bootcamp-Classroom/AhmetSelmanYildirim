using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Entity.Entities;

namespace VetManagement.Services.ServiceAbstracts
{
    public interface IObservationRoomService
    {
        public Task<IEnumerable<ObservationRoom>> GetAllAsync();
        public Task<ObservationRoom> GetAsync(int id);
        public Task UpdateAsync(int id, ObservationRoom observationRoom);
        public Task<ObservationRoom> CreateAsync(ObservationRoom observationRoom);
        public Task DeleteAsync(int id);
    }
}
