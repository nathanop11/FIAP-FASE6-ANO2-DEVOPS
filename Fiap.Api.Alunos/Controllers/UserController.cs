using Microsoft.AspNetCore.Mvc;
using Fiap.Web.Alunos.Models;
using Fiap.Web.Alunos.Services;
using System;
using System.Collections.Generic;

namespace Fiap.Web.Alunos.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserModel>> GetUser()
        {
            var user = _userService.GetUser();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var user = _userService.ObterUserPorId(id);
                if (user == null)
                    return NotFound();

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel user)
        {
            try
            {
                _userService.CriarUser(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {
            try
            {
                var existingUser = _userService.ObterUserPorId(id);
                if (existingUser == null)
                    return NotFound();

                user.UserId = id;
                _userService.AtualizarUser(user);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                var existingUser = _userService.ObterUserPorId(id);
                if (existingUser == null)
                    return NotFound();

                _userService.DeletarUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
