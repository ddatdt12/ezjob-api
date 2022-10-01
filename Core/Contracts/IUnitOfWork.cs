using EzjobApi.Core.Contracts;

namespace EzjobApi.Core.Contracts
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IAuthRepository Auth { get; }
        Task CompleteAsync();
    }
}
