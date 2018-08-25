using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Dapper;
using Npgsql;

namespace Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString = "User ID=asp_user;Password=Password123;Host=localhost;Port=5433;Database=IdentityTest;Pooling=true;";

        public IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public async Task CreateAsync(User user)
        {
            using (IDbConnection conn = Connection)
            {

                string insertQuery = $@"
                    INSERT INTO ""User"" (""DateCreated"", ""DateUpdated"", ""Email"", ""FirstName"", ""Id"", ""LastName"", ""PasswordHash"", ""Username"")  
                    VALUES (@DateCreated, @DateUpdated, @Email, @FirstName, @Id, @LastName, @PasswordHash, @Username)";
                
                conn.Open();
                var result = await conn.ExecuteAsync(insertQuery, user);
            }
        }

        public Task CreateAsync(User user, IUnitOfWork uow)
        {
            string insertQuery = $@"
                    INSERT INTO ""User"" (""DateCreated"", ""DateUpdated"", ""Email"", ""FirstName"", ""Id"", ""LastName"", ""PasswordHash"", ""Username"")  
                    VALUES (@DateCreated, @DateUpdated, @Email, @FirstName, @Id, @LastName, @PasswordHash, @Username)";

            return uow.DbTransaction.Connection.ExecuteAsync(insertQuery, user, uow.DbTransaction);
        }

        public Task<User> GetByIdAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByNameAsync(string name)
        {
            return Task.FromResult<User>(null);
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
