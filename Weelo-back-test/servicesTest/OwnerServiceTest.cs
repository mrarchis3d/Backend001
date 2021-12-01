using FizzWare.NBuilder;
using Models.Dtos;
using Models.Utils;
using Moq;
using NUnit.Framework;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Weelo_back_test.servicesTest
{
    [TestFixture]
    public class OwnerServiceTest
    {
        [Test]
        public void Should_Get_All_Owners()
        {
            var pagging = new Mock<Pagging>();
            var ownerService = new Mock<IOwnerService>();
            IEnumerable<OwnerDTO> owners = Builder<OwnerDTO>.CreateListOfSize(10).Build();
            ownerService.Setup(p => p.GetAllOwner(pagging.Object)).Returns(Task.FromResult(owners));
        }

        [Test]
        public void Should_Create_Owner()
        {
            var ownerDTO = new Mock<OwnerDTO>();
            var ownerService = new Mock<IOwnerService>();
            ownerService.Setup(p => p.Create(ownerDTO.Object)).Returns(Task.CompletedTask);
        }

        [Test]
        public void Should_Update_Owner()
        {
            var ownerDTO = new Mock<OwnerDTO>();
            var ownerService = new Mock<IOwnerService>();
            ownerService.Setup(p => p.Update(ownerDTO.Object)).Returns(Task.CompletedTask);
        }

        [Test]
        public void Should_Delete_Owner()
        {
            var ownerService = new Mock<IOwnerService>();
            ownerService.Setup(p => p.Delete(It.IsAny<Guid>())).Returns(Task.CompletedTask);
        }
    }
}
