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

        [HttpPost]
        public ActionResult Post([FromBody] Post post)
        {
            _context.Posts!.Add(post);
            _context.SaveChanges();

            return new CreatedAtRouteResult("ObterUsuario",
                new { id = post.PostId }, post);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Post post)
        {
            if (id != post.PostId)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
    }
}
