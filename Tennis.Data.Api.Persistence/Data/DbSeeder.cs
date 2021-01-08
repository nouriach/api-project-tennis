using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Persistence.Data
{
    public static class DbSeeder
    {
        public static void Seed(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            JsonSerializer serializer = new JsonSerializer();
            Player player;
            Players players = new Players();

            using (FileStream s = File.Open(@"C:\Users\NOURIACH\source\repos\Projects\TennisAPI\api-project-tennis\Tennis.Data.Api.Persistence\Data\MockTennisData.json", FileMode.Open))
            using (StreamReader sr = new StreamReader(s))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        player = serializer.Deserialize<Player>(reader);
                        players.Add(player);
                    }
                }
            }

            if (!context.Players.Any())
            {
                foreach(var result in players)
                {
                    context.Players.Add(
                        new Player()
                        {
                            FirstName = result.FirstName,
                            LastName = result.LastName,
                            Nationality = result.Nationality,
                            Gender = result.Gender,
                            Age = result.Age,

                            Skill = new Skill()
                            {
                                Speed = result.Skill.Speed,
                                Serve = result.Skill.Serve,
                                Power = result.Skill.Power,
                                Technique = result.Skill.Technique,
                                Endurance = result.Skill.Endurance,
                                Flair = result.Skill.Flair,
                            },

                            Style = new Style()
                            {
                                HardHitter = result.Style.HardHitter,
                                Tactical = result.Style.Tactical,
                                ServeAndVolley = result.Style.ServeAndVolley,
                                GreatReturn = result.Style.GreatReturn,
                                RocketServe = result.Style.RocketServe,
                                SolidDefence = result.Style.SolidDefence,
                            }
                        });
                    context.SaveChanges();
                }
            }
        }
    }
}
