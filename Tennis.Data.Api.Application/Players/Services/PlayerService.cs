using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Domain.Models;
using Tennis.Data.Api.Persistence.Data;

namespace Tennis.Data.Api.Application.Players.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly ApplicationDbContext _context;

        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePlayerAsync(Player playerToCreate)
        {
            // check if player exists
            // if the player does exist retur false
            // if the player doesn't exist create it, add it and save it
            // return created > 0?
            // This probably should return either a new Player or a null...
            throw new NotImplementedException();
        }

        public async Task<bool> DeletePlayerAsync(int playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Player> GetPlayerByIdAsync(int playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Player>> GetPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePlayerAsync(Player playerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
