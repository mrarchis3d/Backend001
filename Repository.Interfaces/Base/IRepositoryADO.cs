using System.Threading.Tasks;

namespace Repository.Interfaces.Base
{
    public interface IRepositoryADO
    {
        public Task<T> Create<T>(string command, object dtoParameters);
        public Task Update(string command, object dtoParameters);
    }
}
