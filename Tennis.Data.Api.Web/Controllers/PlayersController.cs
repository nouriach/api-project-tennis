using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Contracts;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Application.Players.Queries;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Web.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayersController : Controller
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Players.Get)]
        public async Task<IActionResult> Get([FromRoute] int playerId)
        {
            var result = await _mediator.Send(new GetPlayerQuery { Id = playerId });
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // At the moment this doesn't use any of the query
        // In the future it may interact with a checkbox/filter system to adapt what is brought back
        [HttpGet(ApiRoutes.Players.GetAll)]
        public async Task<IActionResult> GetAll([FromRoute] GetAllPlayersQuery query)
        {
            var result = await _mediator.Send(query);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost(ApiRoutes.Players.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePlayerCommand command)
        {
            
            var result = await _mediator.Send(command);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", result.FirstName);

            return Created(locationUri, result);
        }

        [HttpPut(ApiRoutes.Players.Update)]
        public async Task<IActionResult> Update ([FromRoute] int playerId, [FromBody] UpdatePlayerCommand command)
        {
            var updatePlayerCommand = new UpdatePlayerCommand
            {
                Id = playerId,
                Nationality = command.Nationality,
                Gender = command.Gender,
                Age = command.Age,
                FirstName = command.FirstName,
                LastName = command.LastName,

                Skill = new Skill
                {
                    PlayerId = playerId,
                    Endurance = command.Skill.Endurance,
                    Flair = command.Skill.Flair,
                    Power = command.Skill.Power,
                    Serve = command.Skill.Serve,
                    Speed = command.Skill.Speed,
                    Technique = command.Skill.Technique,
                },

                Style = new Style
                {
                    PlayerId = playerId,
                    GreatReturn = command.Style.GreatReturn,
                    HardHitter = command.Style.HardHitter,
                    RocketServe = command.Style.RocketServe,
                    ServeAndVolley = command.Style.ServeAndVolley,
                    SolidDefence = command.Style.SolidDefence,
                    Tactical = command.Style.Tactical,
                }
            };

            var playerToUpdate = await _mediator.Send(updatePlayerCommand);
            return Ok(playerToUpdate);
        }

        [HttpDelete(ApiRoutes.Players.Delete)]
        public async Task<IActionResult> Delete([FromRoute] int playerId)
        {
            var deletePlayer = await _mediator.Send(new DeletePlayerCommand { Id = playerId });
            if(deletePlayer)
            {
                return Content("Result deleted");
            }

            return NotFound();
        }
    }
}
