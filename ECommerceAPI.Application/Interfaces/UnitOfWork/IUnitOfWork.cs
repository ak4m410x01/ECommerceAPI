using ECommerceAPI.Application.Interfaces.Repositories.Base;

namespace ECommerceAPI.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IBaseRepository<T> Repository<T>() where T : class;

        Task<int> SaveAsync();
    }
}