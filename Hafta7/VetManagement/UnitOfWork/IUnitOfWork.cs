using System.Threading.Tasks;
using VetManagement.Services.ServiceAbstracts;

namespace VetManagement.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IAnimalService AnimalService { get; set; }
        public IAssistantService AssistantService { get; set; }
        public IExamRoomService ExamRoomService { get; set; }
        public IObservationRoomService ObservationRoomService { get; set; }
        public IPetOwnerService PetOwnerService{ get; set; }
        public IVeterinarianService VeterinarianService { get; set; }

        Task SaveChangesAsync();
    }
}
