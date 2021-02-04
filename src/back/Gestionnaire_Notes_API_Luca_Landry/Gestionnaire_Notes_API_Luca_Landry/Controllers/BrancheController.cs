using System;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Notes_API_Luca_Landry.Controllers
{
    public class BrancheController : ControllerBase
    {
        private readonly IBrancheService _brancheService;
        
        public BrancheController(IBrancheService brancheService)
        {
            _brancheService = brancheService;
        }
        
        [HttpPost("branches")]
        public IActionResult Add([FromBody]createBrancheDTO newBranche)
        {
            try
            {
                _brancheService.AddBranche(newBranche);
                return Created($"branches/{newBranche.Id}", newBranche);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpDelete("branches/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _brancheService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("branches/{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var u = _brancheService.GetSingle(id);
                return Ok(u);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("branches")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_brancheService.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost("branches/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PatchBrancheModel brancheUpdated)
        {
            try
            {
                return Ok(_brancheService.Update(id, brancheUpdated));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}