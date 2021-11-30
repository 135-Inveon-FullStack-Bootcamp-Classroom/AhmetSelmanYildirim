using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetManagement.Entity.Entities;
using VetManagement.UnitOfWork;

namespace VetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObservationRoomsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ObservationRoomsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObservationRoom>>> GetObservationRooms()
        {
            var observationRooms = await _unitOfWork.ObservationRoomService.GetAllAsync();
            return Ok(observationRooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ObservationRoom>> GetObservationRoom(int id)
        {
            var observationRoom = await _unitOfWork.ObservationRoomService.GetAsync(id);
            return Ok(observationRoom);
        }

        [HttpPost]
        public async Task<ActionResult<ObservationRoom>> AddObservationRoom(ObservationRoom observationRoom)
        {
            var createdObservationRoom = await _unitOfWork.ObservationRoomService.CreateAsync(observationRoom);
            return Ok(createdObservationRoom);
        }

        [HttpPut]
        public async Task<ActionResult<ObservationRoom>> UpdateObservationRoom(int id, ObservationRoom observationRoom)
        {
            await _unitOfWork.ObservationRoomService.UpdateAsync(id, observationRoom);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObservationRoom(int id)
        {
            await _unitOfWork.ObservationRoomService.DeleteAsync(id);
            return NoContent();
        }
    }
}
