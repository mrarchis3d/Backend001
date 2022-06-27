using Repository.Interfaces;
using Repository.Queries;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IOwnerRepository OwnerRepository { get; }


        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            OwnerRepository = new OwnerRepository(context, transaction);
        }
        
    }
}
