using Models.Dtos;
using Models.Utils;
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
        Task<IEnumerable<PropertyWithOwnerDTO>> GetAllPropertyWithOwner(Pagging pagging);
    }
}
