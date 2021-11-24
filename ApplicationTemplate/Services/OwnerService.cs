using AutoMapper;
using Common.Errors;
using Common.Exceptions;
using Models.Dtos;
using Models.Entities;
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
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public OwnerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Method for create Owner
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Create(OwnerDTO dtoOwner)
        {
            using (var unit = this._unitOfWork.CreateRepository())
            {
                Owner owner = _mapper.Map<OwnerDTO, Owner>(dtoOwner);
                await unit.Repositories.OwnerRepository.Create(owner);
            }
        }
        /// <summary>
        /// Method for update owner
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idOwner)
        {
            using (var unit = this._unitOfWork.CreateRepository())
            {
                await unit.Repositories.OwnerRepository.Delete(idOwner);
            }
        }
        /// <summary>
        /// method for get all owners
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OwnerDTO>> GetAllOwner()
        {
            using (var unit = this._unitOfWork.CreateRepository())
            {
                var result =  await unit.Repositories.OwnerRepository.GetAllOwner();
                IEnumerable<OwnerDTO> owners = _mapper.Map<IEnumerable<Owner>, IEnumerable<OwnerDTO>>(result);
                return owners;
            }
        }

        /// <summary>
        /// Method for update Owners
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Update(OwnerDTO dtoOwner)
        {
            using (var unit = this._unitOfWork.CreateRepository())
            {
                Owner owner = _mapper.Map<OwnerDTO, Owner>(dtoOwner);
                await unit.Repositories.OwnerRepository.Update(owner);
            }
        }
    }
}
