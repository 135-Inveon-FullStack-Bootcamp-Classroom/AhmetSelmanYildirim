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
    public class PetOwnerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PetOwnerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PetOwner>>> GetPetOwners()
        {
            var petOwners = await _unitOfWork.PetOwnerService.GetAllAsync();
            return Ok(petOwners);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetOwner>> GetPetOwner(int id)
        {
            var petOwner = await _unitOfWork.PetOwnerService.GetAsync(id);
            return Ok(petOwner);
        }

        [HttpPost]
        public async Task<ActionResult<PetOwner>> AddPetOwner(PetOwner petOwner)
        {
            var createdPetOwner = await _unitOfWork.PetOwnerService.CreateAsync(petOwner);
            return Ok(createdPetOwner);
        }

        [HttpPut]
        public async Task<ActionResult<PetOwner>> UpdatePetOwner(int id, PetOwner petOwner)
        {
            await _unitOfWork.PetOwnerService.UpdateAsync(id, petOwner);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePetOwner(int id)
        {
            await _unitOfWork.PetOwnerService.DeleteAsync(id);
            return NoContent();
        }
    }
}
