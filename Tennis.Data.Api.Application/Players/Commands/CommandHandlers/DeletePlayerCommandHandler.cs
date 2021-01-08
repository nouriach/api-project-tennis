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
    public class DeletePlayerCommandHandler : IRequestHandler<DeletePlayerCommand, Player>
    {
        public Task<Player> Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
