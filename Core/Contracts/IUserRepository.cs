using EzjobApi.Models;
using System.Linq.Expressions;

namespace EzjobApi.Core.Contracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> FindUserByEmailAndPassword(string email, string password);
        Task<User> FindByEmail(string email);
    }
}
