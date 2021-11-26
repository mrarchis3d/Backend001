using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPropertyImageService
    {
        Task Create(PropertyImageDTO propImage);
        Task Delete(Guid idPropImage);
        Task Update(PropertyImageDTO propImage);
        Task<IEnumerable<PropertyImageDTO>> GetAllPropertyImages();
    }
}
