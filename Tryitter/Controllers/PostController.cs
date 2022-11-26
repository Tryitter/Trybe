using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tryitter.Context;
using Tryitter.Models;

namespace Tryitter.Controllers
{
    [Route("api/[Controller]")]
    public class PostController : ControllerBase
    {
        private readonly AppDbContext _context;
        public PostController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetAll()
        {
            var posts = await _context.Posts!.AsNoTracking().ToListAsync();
            if (posts == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }
            return Ok(posts);
        }

        [HttpGet("{id}", Name = "ObterPost")]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            var post = await _context.Posts!.AsNoTracking()
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
            {
                return NotFound("Nenhum usuário encontrado");
            }
            return Ok(post);
        }
    }
}
