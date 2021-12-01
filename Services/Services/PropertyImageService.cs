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
    public class PropertyImageService : IPropertyImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PropertyImageService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Method for create image of property
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Create(PropertyImageDTO propImage)
        {
            using var unit = _unitOfWork.CreateRepository();
            PropertyImage property = _mapper.Map<PropertyImageDTO, PropertyImage>(propImage);
            await unit.Repositories.PropertyImageRepository.Create(property);
        }


        /// <summary>
        /// Method for delete image
        /// </summary>
        /// <param name="idOwner"></param>
        /// <returns></returns>
        public async Task Delete(Guid idPropImage)
        {
            using var unit = _unitOfWork.CreateRepository();
            await unit.Repositories.PropertyImageRepository.Delete(idPropImage);
        }

        /// <summary>
        /// method for get all images from property
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyImageDTO>> GetAllPropertyImages(bool Enabled, Guid IdProperty)
        {
            using var unit = _unitOfWork.CreateRepository();
            var result = await unit.Repositories.PropertyImageRepository.GetAllPropertyImages(Enabled, IdProperty);
            IEnumerable<PropertyImageDTO> images = _mapper.Map<IEnumerable<PropertyImage>, IEnumerable<PropertyImageDTO>>(result);
            return images;
        }

        /// <summary>
        /// Method for update image set enable to image
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Update(bool enabled, Guid IdImage)
        {
            using var unit = _unitOfWork.CreateRepository();
            await unit.Repositories.PropertyImageRepository.Update(enabled, IdImage);
        }

    }
}
