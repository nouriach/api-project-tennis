using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Application.Players.Queries;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.Handlers
{
    class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, Player>
    {
        private readonly IPlayerService _playerService;

        public GetPlayerQueryHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        public async Task<Player> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            var result = await _playerService.GetPlayerByIdAsync(request.Id);
            return result; 
        }
    }
}
