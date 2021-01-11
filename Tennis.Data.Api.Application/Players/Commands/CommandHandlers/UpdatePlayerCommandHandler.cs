using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.CommandHandlers
{
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, Player>
    {
        private readonly IPlayerService _playerService;

        public UpdatePlayerCommandHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<Player> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            Player player = new Player();
            player = request;

            var updatedPlayer = await _playerService.UpdatePlayerAsync(player);

            return updatedPlayer;
        }
    }
}
