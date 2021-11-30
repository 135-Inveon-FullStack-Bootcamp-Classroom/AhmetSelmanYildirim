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
    public class ExamRoomsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ExamRoomsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExamRoom>>> GetExamRooms()
        {
            var examRooms = await _unitOfWork.ExamRoomService.GetAllAsync();
            return Ok(examRooms);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExamRoom>> GetExamRoom(int id)
        {
            var examRoom = await _unitOfWork.ExamRoomService.GetAsync(id);
            return Ok(examRoom);
        }

        [HttpPost]
        public async Task<ActionResult<ExamRoom>> AddExamRoom(ExamRoom examRoom)
        {
            var createdExamRoom = await _unitOfWork.ExamRoomService.CreateAsync(examRoom);
            return Ok(createdExamRoom);
        }

        [HttpPut]
        public async Task<ActionResult<ExamRoom>> UpdateExamRoom(int id, ExamRoom examRoom)
        {
            await _unitOfWork.ExamRoomService.UpdateAsync(id, examRoom);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamRoom(int id)
        {
            await _unitOfWork.ExamRoomService.DeleteAsync(id);
            return NoContent();
        }
    }
}
