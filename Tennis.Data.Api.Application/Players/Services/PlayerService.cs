using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.Services
{
    public class PlayerService : IPlayerService
    {
        public Task<bool> CreatePlayerAsync(Player playerToCreate)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePlayerAsync(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetPlayerByIdAsync(int playerId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Player>> GetPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePlayerAsync(Player playerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
