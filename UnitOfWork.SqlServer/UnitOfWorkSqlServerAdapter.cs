using System.Data.SqlClient;
using UnitOfWork.Interfaces;

namespace UnitOfWork.SqlServer
{
    public class UnitOfWorkSqlServerAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection _context { get; set; }
        private SqlTransaction _transaction { get; set; }
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkSqlServerAdapter(SqlConnection context)
        {
            _context = context;
            _context.Open();
            _transaction = _context.BeginTransaction();
            Repositories = new UnitOfWorkSqlServerRepository(_context, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();
            if (_context!=null)
            {
                _context.Close();
                _context.Dispose();
            }
            Repositories = null;
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
