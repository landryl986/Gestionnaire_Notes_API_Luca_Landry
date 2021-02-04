using System;
using System.IO;
using System.Threading.Tasks;
using Gestionnaire_Notes_API_Luca_Landry.InterfacesService;
using Gestionnaire_Notes_API_Luca_Landry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestionnaire_Notes_API_Luca_Landry.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users")]
        public IActionResult Add([FromBody]CreateUserDTO newUser)
        {
            try
            {

                var user = _userService.AddUser(newUser);

                return Created($"users/{user.Id}", newUser);
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
                //Vu que je retourne rien, pour verifier si le delete marche bien il faut faire un get juste après pour voir si le user a disparus
                _userService.Delete(id);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("users/{id}")]
        public IActionResult GetSingle(int id)
        {
            try
            {
                var u = _userService.GetSingle(id);
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
        
        [HttpGet("users/{email}/{pwd}/login")]
        public IActionResult Login(string email, string pwd)
        {
            try
            {
                return Ok(_userService.Login(email, pwd));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpGet("users/{email}/email")]
        public IActionResult GetByMail(string email)
        {
            try
            {
                return Ok(_userService.GetByMail(email));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("users/{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PatchUserModel userUpdated)
        {
            try
            {
                return Ok(await _userService.UpdateAsync(id, userUpdated));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("users/{Id}/avatar")]
        public IActionResult AddAvatar([FromRoute] int Id, IFormFile file)
        {
            try
            {
                var ms = new MemoryStream();
                file.CopyTo(ms);
                _userService.SetAvatar(Id, ms.ToArray());
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("users/{id}/avatar")]
        public async Task<IActionResult> GetAvatar([FromRoute] int id)
        {
            return File(await _userService.GetAvatar(id), "image/jpeg");
        }
    }
}