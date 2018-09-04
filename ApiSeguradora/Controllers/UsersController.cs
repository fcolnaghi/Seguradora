using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Seguradora.Model;
using Seguradora.Models;
using Seguradora.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly SeguradoraContext _context;
        private readonly IUserRepository _userRepository;

        public UsersController(SeguradoraContext context, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _context = context;
        }

        [HttpGet, AllowAnonymous]
        public IActionResult GetAll()
        {
            return new ObjectResult(_userRepository.GetAll());
        }

        [HttpGet("{id}")] // Matches '/api/user/{id}'
        public IActionResult Get(int id)
        {
            User result = _userRepository.GetById(id);
            if (result != null)
            {
                return new ObjectResult(_userRepository.GetById(id));
            }

            return NotFound("Usuário não encontrado.");
        }

        [HttpDelete("{id}")] // Matches '/api/user/{id}'
        public IActionResult Delete(int id)
        {
            _userRepository.Delete(id);
            return Ok("Usuario removido com sucesso!");
        }

        [HttpPost, AllowAnonymous] // Matches '/api/user
        public IActionResult Save([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            return new ObjectResult(_userRepository.Save(user));
        }
    }
}
