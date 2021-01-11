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



        public async Task<Player> UpdatePlayerAsync(Player update)
        {
            var player = await GetPlayerByIdAsync(update.Id);
            if (player == null)
            {
                throw new InvalidOperationException($"Product '{update.Id}' not found");

            };

            UpdatePlayer(update, player);

            _context.Players.Update(player);
            var updated = await _context.SaveChangesAsync();

            if (updated > 0)
                return player;

            return null;
        }

        private static void UpdatePlayer(Player update, Player player)
        {
            player.Id = player.Id;
            player.Nationality = update.Nationality == "string" ? player.Nationality : update.Nationality;
            player.Gender = update.Gender == "string" ? player.Gender : update.Gender;
            player.Age = update.Age == 0 ? player.Age : update.Age;
            player.FirstName = update.FirstName == "string" ? player.FirstName : update.FirstName;
            player.LastName = update.LastName == "string" ? player.LastName : update.LastName;


            player.Skill.PlayerId = player.Id;
            player.Skill.Endurance = update.Skill.Endurance == 0 ? player.Skill.Endurance : update.Skill.Endurance;
            player.Skill.Flair = update.Skill.Flair == 0 ? player.Skill.Flair : update.Skill.Flair;
            player.Skill.Power = update.Skill.Power == 0 ? player.Skill.Power : update.Skill.Power;
            player.Skill.Serve = update.Skill.Serve == 0 ? player.Skill.Serve : update.Skill.Serve;
            player.Skill.Speed = update.Skill.Speed == 0 ? player.Skill.Speed : update.Skill.Speed;
            player.Skill.Technique = update.Skill.Technique == 0 ? player.Skill.Technique : update.Skill.Technique;

            player.Style.PlayerId = player.Id;
            player.Style.GreatReturn = update.Style.GreatReturn == 0 ? player.Style.GreatReturn : update.Style.GreatReturn;
            player.Style.HardHitter = update.Style.HardHitter == 0 ? player.Style.HardHitter : update.Style.HardHitter;
            player.Style.RocketServe = update.Style.RocketServe == 0 ? player.Style.RocketServe : update.Style.RocketServe;
            player.Style.ServeAndVolley = update.Style.ServeAndVolley == 0 ? player.Style.ServeAndVolley : update.Style.ServeAndVolley;
            player.Style.SolidDefence = update.Style.SolidDefence == 0 ? player.Style.SolidDefence : update.Style.SolidDefence;
            player.Style.Tactical = update.Style.Tactical == 0 ? player.Style.Tactical : update.Style.Tactical;
        }
    }
}
