using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Geometrica.Resources.Models;
using Geometrica.Resources.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Geometrica.Resources
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IRepository repository;
        private Guid UserID => Guid.Parse(User.Claims
            .Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        public GameController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("countries")]
        [Authorize]
        public IEnumerable<Country> GetCountry()
        {
            return repository.GetCountry();
        }
        

        [HttpGet("{userId}/games")]
        public IEnumerable<Game> GetUserGames(int userId)
        {
            return repository.GetUserGames(userId);
        }
    }
}