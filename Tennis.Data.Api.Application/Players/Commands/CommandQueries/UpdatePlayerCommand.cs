﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Tennis.Data.Api.Domain.Models;

namespace Tennis.Data.Api.Application.Players.CommandQueries
{
    public class UpdatePlayerCommand : IRequest<Player>
    {
    }
}
