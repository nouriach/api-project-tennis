using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.Data.Api.Domain.Models.Players.Queries
{
    public class GetAllPlayersQuery : IRequest<IEnumerable<Player>>
    {
    }
}
