using System;
using System.Collections.Generic;
using System.Text;

namespace Tennis.Data.Api.Domain.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Players
        {
            public const string GetAll = Base + "/players";
            public const string Get = Base + "/players/{playerId}";
            public const string Update = Base + "/players/{playerId}";
            public const string Delete = Base + "/players/{playerId}";
            public const string Create = Base + "/players";
        }
    }
}
