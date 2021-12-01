using Repository.Interfaces;
using Repository.SqlServer;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IOwnerRepository OwnerRepository { get; }
        public IPropertyRepository PropertyRepository { get; }
        public IPropertyImageRepository PropertyImageRepository { get; }
        public IPropertyTraceRepository PropertyTraceRepository { get; }

        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            OwnerRepository = new OwnerRepository(context, transaction);
            PropertyRepository = new PropertyRepository(context, transaction);
            PropertyImageRepository = new PropertyImageRepository(context, transaction);
            PropertyTraceRepository = new PropertyTraceRepository(context, transaction);
        }
        
    }
}
