using System;
using System.Collections.Generic;
using System.Text;
using Tennis.Data.Api.Application.Players.CommandQueries;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.Commands.CommandResults
{
    public class CreatePlayerCommandResult
    {
        public CreatePlayerCommandResult(CreatePlayerCommand command)
        {
            Nationality = command.Nationality;
            Gender = command.Gender;
            Age = command.Age;
            FirstName = command.FirstName;
            LastName = command.LastName;

            Skill.Endurance = command.Skill.Endurance;
            Skill.Flair = command.Skill.Flair;
            Skill.Power = command.Skill.Power;
            Skill.Serve = command.Skill.Serve;
            Skill.Speed = command.Skill.Speed;
            Skill.Technique = command.Skill.Technique;

            Style.GreatReturn = command.Style.GreatReturn;
            Style.HardHitter = command.Style.HardHitter;
            Style.RocketServe = command.Style.RocketServe;
            Style.ServeAndVolley = command.Style.ServeAndVolley;
            Style.SolidDefence = command.Style.SolidDefence;
            Style.Tactical = command.Style.Tactical;
        }

        public string Nationality { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Skill Skill { get; set; }
        public Style Style { get; set; }
    }
}
