using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Geometrica.Auth.Resources.Repository;
using Geometrica.Resources;
using Geometrica.Resources.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Geometrica.Auth.Resources.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly IRepository repository;
        private Guid UserID => Guid.Parse(User.Claims
            .Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        
        public AccountController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpDelete("{playerId}/deletePlayer")]
        [Authorize]
        public IActionResult DeletePlayer(int playerId, User user)
        {
            if (repository.DeletePlayer(playerId, user) > 0)
            {
                return Ok("Аккаунт успешно удален");
            }
            return BadRequest();
        }
        
        [HttpPut("updatePlayer")]
        [Authorize]
        public IActionResult UpdatePlayer(Player player)
        {
            if (repository.UpdatePlayer(player) > 0)
            {
                return Ok("Аккаунт успешно обновлен");
            }
            return BadRequest();
        }

        [HttpGet("findFriends/{playerName}")]
        [Authorize]
        public IEnumerable<string> FindFriends(string playerName)
        {
            return repository.FindFriends(playerName);
        }

        [HttpDelete("{userId}/deleteGame/{gameId}")]
        [Authorize]
        public IActionResult DeleteGame(int userId, int gameId, User user)
        {
            if (repository.DeleteGame(userId, gameId, user) > 0)
            {
                return Ok("Игра успешно удалена");
            }
            return BadRequest();
        }
        
    }
}