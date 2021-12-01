using FizzWare.NBuilder;
using Models.Entities;
using Models.Utils;
using Moq;
using NUnit.Framework;
using Repository.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace Weelo_back_test.repositoryTest
{
    [TestFixture]
    public class OwnerRepositoryTest
    {

        [Test]
        public void Should_Get_All_Owners()
        {
            var pagging = new Mock<Pagging>();
            var ownerRepository = new Mock<IOwnerRepository>();
            IEnumerable<Owner> owners = Builder<Owner>.CreateListOfSize(10).Build();
            ownerRepository.Setup(p => p.GetAllOwner(pagging.Object)).Returns(Task.FromResult(owners));
        }


        [Test]
        public void Should_Get_Create_Owner()
        {
            var owner = new Mock<Owner>();
            var ownerRepository = new Mock<IOwnerRepository>();
            ownerRepository.Setup(p => p.Create(owner.Object)).Returns(Task.FromResult(It.IsAny<Guid>()));
        }

        [Test]
        public void Should_Get_Update_Owner()
        {
            var owner = new Mock<Owner>();
            var ownerRepository = new Mock<IOwnerRepository>();
            ownerRepository.Setup(p => p.Update(owner.Object)).Returns(Task.CompletedTask);
        }

        [Test]
        public void Should_Get_Delete_Owner()
        {
            var ownerRepository = new Mock<IOwnerRepository>();
            ownerRepository.Setup(p => p.Delete(It.IsAny<Guid>())).Returns(Task.CompletedTask);
        }
    }
}
