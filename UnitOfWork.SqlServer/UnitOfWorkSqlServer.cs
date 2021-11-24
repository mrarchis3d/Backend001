using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServer : IUnitOfWork
    {
        private readonly IConfiguration _configuration;

        public UnitOfWorkSqlServer(IConfiguration configuration = null)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter CreateRepository()
        {
           var connectionString = new SqlConnection(_configuration.GetConnectionString("TestWeelo"));

            return new UnitOfWorkSqlServerAdapter(connectionString);
        }

    }
}
