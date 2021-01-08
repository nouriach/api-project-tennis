using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Application.Players.Commands.CommandResults;
using Tennis.Data.Api.Application.Players.Queries;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Interfaces
{
    public interface IPlayerService
    {
        Task<List<Player>> GetPlayersAsync(GetAllPlayersQuery query);
        Task<Player> GetPlayerByIdAsync(int playerId);
        Task<bool> UpdatePlayerAsync(Player playerToUpdate);
        Task<bool> DeletePlayerAsync(int playerId);
        Task<CreatePlayerCommandResult> CreatePlayerAsync(CreatePlayerCommand playerToCreate);
    }
}
