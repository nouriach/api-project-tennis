using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Application.Players.Commands.CommandResults;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.CommandHandlers
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Player>
    {
        private readonly IPlayerService _playerservice;

        public CreatePlayerCommandHandler(IPlayerService playerservice)
        {
            _playerservice = playerservice;
        }

        public async Task<Player> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            // this should now head to the service to add a player to the database
            // Does there need to be a CreatePlayerRequest to be passed or just a Player?
            var result = await _playerservice.CreatePlayerAsync(request);

            // The returned player from Service will be sent back below
            return result;
        }
    }
}
