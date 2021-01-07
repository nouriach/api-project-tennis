using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tennis.Data.Api.Domain.Contracts;
using Tennis.Data.Api.Domain.Models;
using Tennis.Data.Api.Domain.Models.Players.Queries;

namespace Tennis.Data.Api.Web.Controllers
{
    public class PlayersController : Controller
    {
        private readonly IMediator _mediator;

        public PlayersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(ApiRoutes.Players.GetAll)]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpPost(ApiRoutes.Players.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePlayerCommand command)
        {
            var result = await _mediator.Send(command);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUri = baseUrl + "/" + ApiRoutes.Players.Get.Replace("{playerId}", result.FirstName);

            return Created(locationUri, result);
        }

    }
}
