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
    public class AssistantsController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public AssistantsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Assistant>>> GetAssistants()
        {
            var assistants = await _unitOfWork.AssistantService.GetAllAsync();
            return Ok(assistants);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Assistant>> GetAssistant(int id)
        {
            var assistant = await _unitOfWork.AssistantService.GetAsync(id);
            return Ok(assistant);
        }

        [HttpPost]
        public async Task<ActionResult<Assistant>> AddAssistant(Assistant assistant)
        {
            var createdAssistant = await _unitOfWork.AssistantService.CreateAsync(assistant);
            return Ok(createdAssistant);
        }

        [HttpPut]
        public async Task<ActionResult<Assistant>> UpdateAssistant(int id, Assistant assistant)
        {
            await _unitOfWork.AssistantService.UpdateAsync(id, assistant);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssistant(int id)
        {
            await _unitOfWork.AssistantService.DeleteAsync(id);
            return NoContent();
        }

    }
}
