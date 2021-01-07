using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.CommandHandlers
{
    public class UpdatePlayerCommandHandler : IRequestHandler<UpdatePlayerCommand, Player>
    {
        public Task<Player> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
