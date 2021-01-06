using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("api/v1/players")]
        public IActionResult GetAll()
        {
            return Ok(_players);
        }
    }
}
