using System.Data;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Npgsql;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string connectionString = "User ID=asp_user;Password=Password123;Host=localhost;Port=5433;Database=IdentityTest;Pooling=true;";
        private NpgsqlTransaction _dbTransaction;
        private NpgsqlConnection _dbConnection;

        protected IDbConnection DbConnection { get => _dbConnection; }
        public IDbTransaction DbTransaction { get => _dbTransaction; }
        
        public UnitOfWork()
        {
            _dbConnection = new NpgsqlConnection(connectionString);
            _dbTransaction = _dbConnection.BeginTransaction();
        }
        
        public Task CommitAsync()
        {
            try
            {
                _dbConnection.Open();
                return _dbTransaction.CommitAsync();
            }
            catch
            {
                _dbTransaction.Rollback();
                throw;
            }
            finally
            {
                _dbTransaction.Dispose();
                DbConnection.Close();
            }
        }

        public void Dispose()
        {
            if (DbTransaction != null)
            {
                _dbTransaction.Dispose();
                _dbTransaction = null;
            }

            if (DbConnection != null)
            {
                DbConnection.Dispose();
                _dbConnection = null;
            }
        }
    }
}
