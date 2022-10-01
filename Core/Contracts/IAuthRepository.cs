using EzjobApi.Models;

namespace EzjobApi.Core.Contracts
{
    public interface IAuthRepository
    {
        string GenerateToken(User user);
    }
}
