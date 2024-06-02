using ECommerceAPI.Application.Interfaces.Specifications.Base;

namespace ECommerceAPI.Application.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync(IBaseSpecification<T> specification);

        Task<T?> FindAsync(IBaseSpecification<T> specification);
    }
}