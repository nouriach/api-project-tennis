using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Domain.Models.Players.Queries;

namespace Tennis.Data.Api.Domain.Models.Players.Handlers
{
    class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, Player>
    {
        public Task<Player> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
