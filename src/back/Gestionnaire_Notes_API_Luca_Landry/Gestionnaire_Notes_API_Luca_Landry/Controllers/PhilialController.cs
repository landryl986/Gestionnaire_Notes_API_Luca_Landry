using System;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Notes_API_Luca_Landry.Controllers
{
    public class PhilialController : ControllerBase
    {
        private readonly IPhilialService _philialService;
        
        public PhilialController(IPhilialService philialService)
        {
            _philialService = philialService;
        }
        
        [HttpPost("philials")]
        public IActionResult Add(createPhilialDTO newPhilial)
        {
            try
            {
                _philialService.AddPhilial(newPhilial);
                return Created($"philials/{newPhilial.Id}", newPhilial);
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
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("philials/{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var u = _philialService.GetSingle(id);
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
        public IActionResult Update([FromRoute] int id, [FromBody] PatchPhilialModel philialUpdated)
        {
            try
            {
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