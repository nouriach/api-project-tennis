using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Application.Players.Commands.CommandResults;


namespace Tennis.Data.Api.Application.Players.CommandHandlers
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
