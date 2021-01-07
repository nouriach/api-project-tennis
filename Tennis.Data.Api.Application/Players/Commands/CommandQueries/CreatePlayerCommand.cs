using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.Data.Api.Application.Players.Commands.CommandResults;

namespace Tennis.Data.Api.Application.Players.CommandQueries
{
    public class CreatePlayerCommand : IRequest<CreatePlayerCommandResult>
    {
        public string FirstName { get; set; }
    }
}
