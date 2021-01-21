using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Auth.Common;
using Geometrica.Auth.Models;
using Geometrica.Auth.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Geometrica.Auth.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IRepository repository;
        private readonly IOptions<AuthOptions> options;
        
        public AccountController(IRepository repository, IOptions<AuthOptions> options)
        {
            this.repository = repository;
            this.options = options;
        }

        [HttpPost("signUp")]
        public IActionResult SignUp(Player player)
        {
            if (repository.SignUp(player) is null) return Unauthorized();
            var token = GenerateJWT(player);
            return Ok(new
            {
                access_token = token, player
            });

        }
        [HttpPost("signIn")]
        public IActionResult SignIn([FromBody]User request)
        {
            var user = repository.SignIn(request);
            if (user is null) return Unauthorized();
            var token = GenerateJWT(user);
            return Ok(new
            {
                access_token = token, user
            });
        }
        
        private string GenerateJWT(Player player)
        {
            var authParams = options.Value;
            var secretKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new (JwtRegisteredClaimNames.Email, player.Email),
                new(JwtRegisteredClaimNames.Sub, player.Uid.ToString())
            };
            var token = new JwtSecurityToken(
                authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}