using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            Players players;


        }
    }
}
