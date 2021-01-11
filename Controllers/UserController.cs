using System;
using System.IO;
using Gestionnaire_Notes_API_Luca_Landry.Interfaces;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Notes_API_Luca_Landry.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUser _userService;
        
        public UserController(IUser userService)
        {
            _userService = userService;
        }

        [HttpPost("users")]
        public IActionResult Add(UserModel newUser)
        {
            try
            {
                if (_userService.ExistsByName(newUser.userName)) return BadRequest();
                if (_userService.ExistsById(newUser.Id)) return BadRequest();

                _userService.AddUser(newUser);

                return Created($"users/{newUser.Id}", newUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("users/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NoContent();
            }
        }

        [HttpGet("users/{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var u = _userService.GetSingle(id);
                if (u == null) return NotFound();
                return Ok(u);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("users")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("users/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UserModel userUpdated)
        {
            try
            {
                if (!_userService.ExistsById(id)) return NotFound();
                return Ok(_userService.Update(id, userUpdated));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("users/{Id}/avatar")]
        public IActionResult AddAvatar([FromRoute] int id, IFormFile file)
        {
            try
            {
                var ms = new MemoryStream();
                file.CopyTo(ms);
                _userService.SetAvatar(id, ms.ToArray());
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("users/{id}/avatar")]
        public IActionResult GetAvatar([FromRoute] int id)
        {
            return File(_userService.GetAvatar(id), "image/jpeg");
        }
    }
}