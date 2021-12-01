using AutoMapper;
using Models.Entities;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnitOfWork.Interfaces;

namespace Services.Services
{
    public class PropertyTraceService : IPropertyTraceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PropertyTraceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        /// <summary>
        /// Method for create Property Trace
        /// </summary>
        /// <param name="dtoOwner"></param>
        /// <returns></returns>
        public async Task Create(PropertyTrace propertyTrace)
        {
            using var unit = _unitOfWork.CreateRepository();
            await unit.Repositories.PropertyTraceRepository.Create(propertyTrace);
        }
        /// <summary>
        /// Delete property trace
        /// </summary>
        /// <param name="idtrace"></param>
        /// <returns></returns>
        public async Task Delete(Guid idtrace)
        {
            using IUnitOfWorkAdapter unit = _unitOfWork.CreateRepository();
            await unit.Repositories.PropertyTraceRepository.Delete(idtrace);
        }
        /// <summary>
        /// Get all traces from property
        /// </summary>
        /// <param name="idProperty"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PropertyTrace>> GetPropertyTraces(Guid idProperty)
        {
            using var unit = _unitOfWork.CreateRepository();
            return await unit.Repositories.PropertyTraceRepository.GetPropertyTraces(idProperty);
        }
        /// <summary>
        /// update property trace
        /// </summary>
        /// <param name="propertyTrace"></param>
        /// <returns></returns>
        public async Task Update(PropertyTrace propertyTrace)
        {
            using var unit = _unitOfWork.CreateRepository();
            await unit.Repositories.PropertyTraceRepository.Update(propertyTrace);
        }
    }
}
