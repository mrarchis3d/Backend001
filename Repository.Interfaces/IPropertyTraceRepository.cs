using Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IPropertyTraceRepository
    {
        Task Create(PropertyTrace propertyTrace);
        Task Delete(Guid idtrace);
        Task Update(PropertyTrace propertyTrace);
        Task<IEnumerable<PropertyTrace>> GetPropertyTraces(Guid idProperty);
    }
}
