using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tryitter.Context;
using Tryitter.Services;

namespace Tryitter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] AuthenticationRequest authenticationRequest)
        {

            // checks for existing user:
            var existingUser = _context.Users!.FirstOrDefault(user => user.Email == authenticationRequest.Email && user.Password == authenticationRequest.Password);
            if (existingUser != null)
            {
                var jwtAuthenticationManager = new JwtAuthenticationManager();
                var authResult = jwtAuthenticationManager.Authenticate(authenticationRequest.Email!);
                return Ok(authResult);
            }
            else
            {
                return Unauthorized();
            }

        }
    }
}
