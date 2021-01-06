using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.Data.Api.Domain.Models.Players.Commands.CommandResults;

namespace Tennis.Data.Api.Domain.Models.Players.Queries
{
    public class CreatePlayerCommand : IRequest<CreatePlayerCommandResult>
    {
        public string FirstName { get; set; }
    }
}
