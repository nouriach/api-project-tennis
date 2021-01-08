using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Application.Players.Commands.CommandResults;
using Tennis.Data.Api.Application.Players.Queries;
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

        // MAKE ALL ASYNC/AWAIT
        public async Task<Player> GetPlayerByIdAsync(int playerId)
        {
            var result = await _context.Players
                .Where(x => x.Id == playerId)
                .Include(skill => skill.Skill)
                .Include(style => style.Style)
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<List<Player>> GetPlayersAsync(GetAllPlayersQuery query)
        {
            var result = await _context.Players
                .Include(skill => skill.Skill)
                .Include(style => style.Style)
                .ToListAsync();

            return result;
        }
        public async Task<Player> CreatePlayerAsync(CreatePlayerCommand playerToCreate)
        {
            var exists = await _context.Players
                .Where(x =>
                    x.FirstName == playerToCreate.FirstName &&
                    x.LastName == playerToCreate.LastName &&
                    x.Age == playerToCreate.Age &&
                    x.Gender == playerToCreate.Gender &&
                    x.Nationality == playerToCreate.Nationality)
                .SingleOrDefaultAsync();

            if (exists != null)
                return null;

            //var addPlayer = new CreatePlayerCommandResult(playerToCreate);
            Player p = new Player
            {
                Nationality = playerToCreate.Nationality,
                Gender = playerToCreate.Gender,
                Age = playerToCreate.Age,
                FirstName = playerToCreate.FirstName,
                LastName = playerToCreate.LastName,

                Skill = new Skill
                {
                    Endurance = playerToCreate.Skill.Endurance,
                    Flair = playerToCreate.Skill.Flair,
                    Power = playerToCreate.Skill.Power,
                    Serve = playerToCreate.Skill.Serve,
                    Speed = playerToCreate.Skill.Speed,
                    Technique = playerToCreate.Skill.Technique,
                },

                Style = new Style
                {
                    GreatReturn = playerToCreate.Style.GreatReturn,
                    HardHitter = playerToCreate.Style.HardHitter,
                    RocketServe = playerToCreate.Style.RocketServe,
                    ServeAndVolley = playerToCreate.Style.ServeAndVolley,
                    SolidDefence = playerToCreate.Style.SolidDefence,
                    Tactical = playerToCreate.Style.Tactical,
                }
            };

            _context.Players.Add(p);
            _context.SaveChanges();

            return p;
        }

        public async Task<bool> DeletePlayerAsync(int playerId)
        {
            var playerToDelete = await GetPlayerByIdAsync(playerId);
            if (playerToDelete == null)
                return false;

            _context.Players.Remove(playerToDelete);
            // _context.Skills.Remove(playerToDelete.Skill);
            // _context.Styles.Remove(playerToDelete.Style);

            _context.SaveChanges();

            return true;
        }



        public Task<bool> UpdatePlayerAsync(Player playerToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
