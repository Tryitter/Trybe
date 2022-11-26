using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Context;
using Tryitter.Models;

namespace Tryitter.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _context.Users!.AsNoTracking().ToListAsync();
            if (users == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }
            return Ok(users);
        }

        [HttpGet("{id}", Name = "ObterUsuario")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var users = await _context.Users!.AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == id);

            if (users == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }
            return Ok(users);
        }

        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            var emailExist = _context.Users!.FirstOrDefault(u => u.Email == user.Email);
            if (emailExist != null)
            {
                return BadRequest("Email já esta cadastrado");
            }
            _context.Users!.Add(user);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<User> Delete(int id)
        {
            var user = _context.Users!.FirstOrDefault(p => p.UserId == id);

            if (user == null)
            {
                return NotFound();
            }

            _context.Users!.Remove(user);
            _context.SaveChanges();
            return user;
        }
    }
}
