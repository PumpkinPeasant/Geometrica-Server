using System.Collections;
using System.Collections.Generic;
using Geometrica_Server.Models;
using Geometrica_Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Geometrica_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IRepository repository;

        public AccountController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost("signUp")]
        public Player SignUp(Player player)
        {
            return repository.SignUp(player);
            
        }
        [HttpPost("signIn")]
        public Player SignIn(User user)
        {
            return repository.SignIn(user);
        }
        
        
        [HttpGet("genders")]
        public IEnumerable<Gender> GetGenders()
        {
            return repository.GetGenders();
        }
    }
}