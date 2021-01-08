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
    class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, IEnumerable<Player>>
    {
        private readonly IPlayerService _playerService;

        public GetAllPlayersQueryHandler(IPlayerService playerService)
        {
            _playerService = playerService;
        }

        public async Task<IEnumerable<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {
            var result = await _playerService.GetPlayersAsync(request);
            return result;
        }
    }
}
