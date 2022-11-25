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

        [HttpGet("{id}", Name ="ObterUsuario")]
        public async Task<ActionResult<User>> GetById(int id )
        {
            var users = await _context.Users!.AsNoTracking()
                .FirstOrDefaultAsync(p => p.UserId == id);

            if(users == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }
            return Ok(users);
        }

        [HttpPost]
        public ActionResult Post([FromBody]User user) 
        {
            _context.Users!.Add(user);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = user.UserId }, user);
        }
    }
}
