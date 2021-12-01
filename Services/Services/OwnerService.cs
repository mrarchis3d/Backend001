using AutoMapper;
using Common.Functions;
using Models.Dtos;
using Models.Entities;
using Models.Utils;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace ServiceGrpcTest.Services
{
    /// <summary>
    /// Implementation service for owners
    /// </summary>
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public OwnerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Method for create Owner
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Create(OwnerDTO dtoOwner)
        {
            using var unit = _unitOfWork.CreateRepository();
            Owner owner = _mapper.Map<OwnerDTO, Owner>(dtoOwner);
            await unit.Repositories.OwnerRepository.Create(owner);
        }
        /// <summary>
        /// Method for update owner
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idOwner)
        {
            using IUnitOfWorkAdapter unit = _unitOfWork.CreateRepository();
            await unit.Repositories.OwnerRepository.Delete(idOwner);
        }
        /// <summary>
        /// method for get all owners
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OwnerDTO>> GetAllOwner(Pagging pagging)
        {
            using var unit = _unitOfWork.CreateRepository();
            var result = await unit.Repositories.OwnerRepository.GetAllOwner(pagging);
            IEnumerable<OwnerDTO> owners = _mapper.Map<IEnumerable<Owner>, IEnumerable<OwnerDTO>>(result);
            owners = String.IsNullOrEmpty(pagging.filter) ? owners : Utilities.FilterByProperty(owners, pagging.filter);
            owners = String.IsNullOrEmpty(pagging.orderAsc) ? owners : Utilities.OrderByAscProperty(owners, pagging.orderAsc);
            owners = String.IsNullOrEmpty(pagging.orderDesc) ? owners : Utilities.OrderByDescProperty(owners, pagging.orderDesc);
            
            return owners;
        }

        /// <summary>
        /// Method for update Owners
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Update(OwnerDTO dtoOwner)
        {
            using var unit = _unitOfWork.CreateRepository();
            Owner owner = _mapper.Map<OwnerDTO, Owner>(dtoOwner);
            await unit.Repositories.OwnerRepository.Update(owner);
        }
    }
}
