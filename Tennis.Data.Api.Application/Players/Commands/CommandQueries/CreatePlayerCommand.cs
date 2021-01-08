using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.Data.Api.Application.Players.Commands.CommandResults;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.CommandQueries
{
    public class CreatePlayerCommand : IRequest<Player>
    {
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Skill Skill { get; set; }
        public Style Style { get; set; }
    }
}
