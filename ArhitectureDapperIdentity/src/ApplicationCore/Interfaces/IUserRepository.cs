using System;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IUserRepository
    {
        Task CreateAsync(User user);

        Task<User> GetByIdAsync(Guid Id);

        Task UpdateAsync(User user);

        Task DeleteAsync(Guid Id);

        Task<User> GetByNameAsync(string name);
    }
}
