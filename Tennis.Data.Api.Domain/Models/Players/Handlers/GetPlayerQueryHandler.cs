using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Domain.Models.Players.Queries;

namespace Tennis.Data.Api.Domain.Models.Players.Handlers
{
    class GetPlayerQueryHandler : IRequestHandler<GetPlayerQuery, Player>
    {
        public Task<Player> Handle(GetPlayerQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
