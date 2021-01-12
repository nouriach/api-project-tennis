using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using Tennis.Data.Api.Domain.Models;
using Tennis.Data.Api.Persistence.Data;
using EntityFrameworkCoreMock;
using Tennis.Data.Api.Application.Interfaces;
using Tennis.Data.Api.Application.Players.Services;

namespace Tennis.Data.Api.Application.UnitTests
{
    public class WhenCallingPlayerService
    {
        // Arrange
        // Act
        // Assert

        public DbContextOptions<ApplicationDbContext> DummyOptions { get; } = 
            new DbContextOptionsBuilder<ApplicationDbContext>().Options;

        [Test]
        public async Task Then_Getting_Player_By_Id_And_Return_Player()
        {
            // Arrange
            var initialEntities = new[]
            {
                new Player {Id = 1, FirstName = "Nathan"},
                new Player {Id = 2, FirstName = "Luis"},
            };
            var dbContextMock = new DbContextMock<ApplicationDbContext>(DummyOptions);
            var usersDbSetMock = dbContextMock.CreateDbSetMock(x => x.Players, initialEntities);
            // dbContextMock.Setup(x => x.Set<Player>()).Returns(usersDbSetMock.Object);

            // Act
            IPlayerService _sut = new PlayerService(dbContextMock.Object);
            var actual = await _sut.GetPlayerByIdAsync(1);
            var expected = initialEntities[0];

            // Assert        
            Assert.AreEqual(expected.Id, actual.Id);
        }
    }
}
