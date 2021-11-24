﻿using Repository.Interfaces;
using Repository.SqlServer;
using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
    {
        public IOwnerRepository OwnerRepository { get; }
        public UnitOfWorkSqlServerRepository(SqlConnection context, SqlTransaction transaction)
        {
            this.OwnerRepository = new OwnerRepository(context,
                transaction);
        }
        
    }
}
