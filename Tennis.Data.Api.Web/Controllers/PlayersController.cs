using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis.Data.Api.Domain.Contracts;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Web.Controllers
{
    public class PlayersController : Controller
    {
        private List<Player> _players;

        public PlayersController()
        {
            _players = new List<Player>();

            for (int i = 0; i < 5; i++)
            {
                _players.Add(new Player { FirstName = Guid.NewGuid().ToString() });
            }
        }

        [HttpGet(ApiRoutes.Players.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_players);
        }

        [HttpPost(ApiRoutes.Players.Create)]
        public IActionResult Create([FromBody] Player player)
        {
            if (!string.IsNullOrEmpty(player.FirstName))
            {
                player.FirstName = Guid.NewGuid().ToString();
            }
            _players.Add(player);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", player.FirstName);

            return Created(locationUri, player);
        }

    }
}
