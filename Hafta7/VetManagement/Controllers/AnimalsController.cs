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
    public class AnimalsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
        {
            var animals = await _unitOfWork.AnimalService.GetAllAsync();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Animal>> GetAnimal(int id)
        {
            var animal = await _unitOfWork.AnimalService.GetAsync(id);
            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<Animal>> AddAnimal(Animal animal)
        {
            var createdAnimal = await _unitOfWork.AnimalService.CreateAsync(animal);
            return Ok(createdAnimal);
        }

        [HttpPut]
        public async Task<ActionResult<Animal>> UpdateAnimal(int id, Animal animal)
        {
            await _unitOfWork.AnimalService.UpdateAsync(id, animal);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            await _unitOfWork.AnimalService.DeleteAsync(id);
            return NoContent();
        }

    }
}
