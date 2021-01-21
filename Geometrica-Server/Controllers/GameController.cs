using System.Collections;
using System.Collections.Generic;
using Geometrica_Server.Models;
using Geometrica_Server.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Geometrica_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : Controller
    {
        private readonly IRepository repository;

        public GameController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("countries")]
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