using AutoMapper;
using Models.Dtos;
using Models.Entities;
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
                PropertyImage propImage = _mapper.Map<PropertyImageDTO, PropertyImage>(prop);
                propImage.IdProperty = idProperty;
                await unit.Repositories.PropertyImageRepository.Create(propImage);
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
        public async Task<IEnumerable<PropertyDTO>> GetAllProperties()
        {
            using var unit = _unitOfWork.CreateRepository();
            var result = await unit.Repositories.PropertyRepository.GetAllProperties();
            IEnumerable<PropertyDTO> owners = _mapper.Map<IEnumerable<Property>, IEnumerable<PropertyDTO>>(result);
            return owners;
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
