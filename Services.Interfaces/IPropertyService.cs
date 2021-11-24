using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPropertyService
    {
        Task Create(PropertyDTO propertyDto);
        Task Delete(Guid idProperty);
        Task Update(PropertyDTO propertyDto);
        Task<IEnumerable<PropertyDTO>> GetAllProperties();
    }
}
