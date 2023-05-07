

using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using MoqProject.API.Controllers;
using MoqProject.API.Interfaces;
using MoqProject.API.Models;
using MoqProject.API.Persistence;
using MoqProject.API.Services;
using MoqProject.UnitTest.Helpers;

namespace MoqProject.UnitTest.Systems.Controllers
{
    public class DistroListControllerTest
    {
        [Fact]
        public async Task Successful_Get_Returns_200()
        {
            // Arrange
            var distro = DistroHelper.GenerateFakeDistro();

            var mockDb = new Mock<DistroDbContext>();
            var mockDistroService = new Mock<DistroListService>(mockDb.Object);
            mockDistroService.Setup(p => p.GetDistroById(It.IsAny<int>())).ReturnsAsync(distro);

            var mockLogger = new Mock<ILogger<DistroListController>>();
            var sut = new DistroListController(mockLogger.Object, mockDistroService.Object);

            // Act
            var result = await sut.GetDistro(It.IsAny<int>());
            var obj = result as IStatusCodeActionResult;

            // Assert
            Assert.NotNull(obj);
            Assert.Equal(200, obj.StatusCode);
        }

        [Fact]
        public async Task Empty_Distro_Returns_404_Not_Found()
        {
            // Arrange
            var distro = DistroHelper.GenerateFakeDistro();

            var mockDb = new Mock<DistroDbContext>();

            var mockDistroService = new Mock<DistroListService>(mockDb.Object);
            mockDistroService.Setup(p => p.GetDistroById(It.IsAny<int>())).Returns(Task.FromResult<DistributionList>(null));

            var mockLogger = new Mock<ILogger<DistroListController>>();

            var sut = new DistroListController(mockLogger.Object, mockDistroService.Object);

            // Act
            var result = await sut.GetDistro(1);
            var obj = result as IStatusCodeActionResult;

            // Assert
            Assert.NotNull(obj);
            Assert.Equal(404, obj.StatusCode);
        }
    }
}