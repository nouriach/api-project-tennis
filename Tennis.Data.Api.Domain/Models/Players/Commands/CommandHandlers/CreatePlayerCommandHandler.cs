using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Domain.Models.Players.Commands.CommandResults;
using Tennis.Data.Api.Domain.Models.Players.Queries;

namespace Tennis.Data.Api.Domain.Models.Players.Handlers
{
    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, CreatePlayerCommandResult>
    {
        public Task<CreatePlayerCommandResult> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var result =  new CreatePlayerCommandResult
            {
                FirstName = request.FirstName
            };
            return Task.FromResult(result);

        }
    }
}
