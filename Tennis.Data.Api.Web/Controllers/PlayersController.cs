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
        public async Task<IActionResult> Update ([FromBody] UpdatePlayerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpDelete(ApiRoutes.Players.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeletePlayerCommand command)
        {
            var deletePlayer = await _mediator.Send(command);
            return NotFound();
        }
    }
}
