using System;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Notes_API_Luca_Landry.Controllers
{
    public class PhilialController : ControllerBase
    {
        private readonly IPhilial _philialService;
        
        public PhilialController(IPhilial philialService)
        {
            _philialService = philialService;
        }
        
        [HttpPost("philials")]
        public IActionResult Add(createPhilialDTO newPhilial)
        {
            try
            {
                if (_philialService.ExistsByName(newPhilial.philialName)) return BadRequest();
                if (_philialService.ExistsById(newPhilial.Id)) return BadRequest();

                _philialService.AddPhilial(newPhilial);

                return Created($"users/{newPhilial.Id}", newPhilial);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpDelete("philials/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _philialService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
        
        [HttpGet("philials/{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var u = _philialService.GetSingle(id);
                if (u == null) return NotFound();
                return Ok(u);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("philials")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_philialService.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost("philials/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PhilialModel philialUpdated)
        {
            try
            {
                if (!_philialService.ExistsById(id)) return NotFound();
                return Ok(_philialService.Update(id, philialUpdated));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}