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

namespace Services.Services
{
    /// <summary>
    /// Services for property entity
    /// </summary>
    public class PropertyService : IPropertyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PropertyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Method for create property
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Create(PropertyDTO propertyDto)
        {
            using var unit = _unitOfWork.CreateRepository();
            Property property = _mapper.Map<PropertyDTO, Property>(propertyDto);
            var idProperty = await unit.Repositories.PropertyRepository.Create(property);
            foreach(PropertyImageDTO prop in propertyDto.images)
            {
                using var unitim = _unitOfWork.CreateRepository();
                PropertyImage propImage = _mapper.Map<PropertyImageDTO, PropertyImage>(prop);
                propImage.IdProperty = idProperty;
                await unitim.Repositories.PropertyImageRepository.Create(propImage);
            }
        }


        /// <summary>
        /// Method for update property
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idProperty)
        {
            using var unit = _unitOfWork.CreateRepository();
            await unit.Repositories.PropertyRepository.Delete(idProperty);
        }


        /// <summary>
        /// method for get all properties
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyWithOwnerDTO>> GetAllPropertyWithOwner(Pagging pagging)
        {
            using var unit = _unitOfWork.CreateRepository();
            var result = await unit.Repositories.PropertyRepository.GetAllPropertyWithOwner(pagging);
            result = String.IsNullOrEmpty(pagging.filter) ? result : Utilities.FilterByProperty(result, pagging.filter);
            result = String.IsNullOrEmpty(pagging.orderAsc) ? result : Utilities.OrderByAscProperty(result, pagging.orderAsc);
            result = String.IsNullOrEmpty(pagging.orderDesc) ? result : Utilities.OrderByDescProperty(result, pagging.orderDesc);

            return result;
        }

        /// <summary>
        /// Method for update Properties
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Update(PropertyDTO propertyDto)
        {
            using var unit = _unitOfWork.CreateRepository();
            Property property = _mapper.Map<PropertyDTO, Property>(propertyDto);
            await unit.Repositories.PropertyRepository.Update(property);
        }
    }
}
