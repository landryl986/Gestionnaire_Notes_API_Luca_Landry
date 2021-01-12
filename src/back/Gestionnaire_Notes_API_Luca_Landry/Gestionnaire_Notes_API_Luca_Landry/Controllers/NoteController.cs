using System;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Notes_API_Luca_Landry.Controllers
{
    public class NoteController : ControllerBase
    {
        private readonly INote _noteService;
        
        public NoteController(INote noteService)
        {
            _noteService = noteService;
        }
        
        [HttpPost("notes")]
        public IActionResult Add(createNoteDTO newNote)
        {
            try
            {
                if (_noteService.ExistsById(newNote.Id)) return BadRequest();

                _noteService.AddNote(newNote);

                return Created($"notes/{newNote.Id}", newNote);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpDelete("notes/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _noteService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }
        
        [HttpGet("notes/{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var u = _noteService.GetSingle(id);
                if (u == null) return NotFound();
                return Ok(u);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("notes")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_noteService.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost("notes/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PatchNoteModel noteUpdated)
        {
            try
            {
                if (!_noteService.ExistsById(id)) return NotFound();
                return Ok(_noteService.Update(id, noteUpdated));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}