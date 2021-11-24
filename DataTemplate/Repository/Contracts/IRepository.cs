using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataTemplate.Repository.Contracts
{
    public interface IRepository 
    {
        Task<IEnumerable<T>> ExcecuteSP<T>(string commandName, Object dtoParameters) where T : class, new();
    }
}
