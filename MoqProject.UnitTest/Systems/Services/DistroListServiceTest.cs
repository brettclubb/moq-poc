using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;
using MoqProject.API.Controllers;
using MoqProject.API.Models;
using MoqProject.API.Persistence;
using MoqProject.API.Services;
using MoqProject.UnitTest.Helpers;
using System.Threading;

namespace MoqProject.UnitTest.Systems.Services
{
    public class DistroListServiceTest
    {
        [Fact]
        public async void Get_Valid_Distro_By_Id_Returns_List()
        {
            // Arrange
            int count = 5;
            var distro = DistroHelper.GenerateFakeDistros(count);

            var mockDb = new Mock<DistroDbContext>();
            mockDb.Setup(x => x.DistributionLists).ReturnsDbSet(distro);

            var sut = new DistroListService(mockDb.Object);

            // Act
            var result = await sut.GetDistroById(1);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<DistributionList>(result);
        }

        [Fact]
        public void Create_Distro_Save_Obj_Once()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<DistributionList>>();

            var mockDb =new Mock<DistroDbContext>();
            mockDb.Setup(x => x.DistributionLists).Returns(mockDbSet.Object);
            mockDb.Setup(c => c.SaveChanges()).Verifiable();

            var sut = new DistroListService(mockDb.Object);

            // Act
            var result = sut.Create("test", DistroHelper.GenerateFakeContactList(5));

            // Assert
            Assert.IsType<DistributionList>(result);
            mockDbSet.Verify(x => x.Add(It.IsAny<DistributionList>()), Times.Once());
            mockDb.Verify(x => x.SaveChanges(), Times.Once());
        }

        [Fact]
        public void Create_Distro_Fail_Throws_DbError()
        {
            // Arrange
            var mockDbSet = new Mock<DbSet<DistributionList>>();

            var mockDb = new Mock<DistroDbContext>();
            mockDb.Setup(x => x.DistributionLists).Returns(mockDbSet.Object);
            mockDb.Setup(c => c.SaveChanges()).Throws(new DbUpdateConcurrencyException());

            var sut = new DistroListService(mockDb.Object);

            // Act & Assert
            Assert.Throws<DbUpdateConcurrencyException>(() => sut.Create("test", DistroHelper.GenerateFakeContactList(5)));
            mockDbSet.Verify(x => x.Add(It.IsAny<DistributionList>()), Times.Once());
            mockDb.Verify(x => x.SaveChanges(), Times.AtMostOnce());
        }
    }
}