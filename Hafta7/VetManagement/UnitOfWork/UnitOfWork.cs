using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Data;
using VetManagement.Services.ServiceAbstracts;

namespace VetManagement.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VetDbContext _dbContext;


        public UnitOfWork(VetDbContext dbContext, IAnimalService animalService, IAssistantService assistantService, IExamRoomService examRoomService, IObservationRoomService observationRoomService, IPetOwnerService petOwnerService, IVeterinarianService veterinarianService)
        {
            _dbContext = dbContext;
            AnimalService = animalService;
            AssistantService = assistantService;
            ExamRoomService = examRoomService;
            ObservationRoomService = observationRoomService;
            PetOwnerService = petOwnerService;
            VeterinarianService = veterinarianService;
        }

        public IAnimalService AnimalService { get; set; }
        public IAssistantService AssistantService { get; set; }
        public IExamRoomService ExamRoomService { get; set; }
        public IObservationRoomService ObservationRoomService { get; set; }
        public IPetOwnerService PetOwnerService { get; set; }
        public IVeterinarianService VeterinarianService { get; set; }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
