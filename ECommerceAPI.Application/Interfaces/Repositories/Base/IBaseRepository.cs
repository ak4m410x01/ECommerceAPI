using ECommerceAPI.Application.Interfaces.Specifications.Base;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Application.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        #region Get All

        Task<IQueryable<T>> GetAllAsync(IBaseSpecification<T> specification);

        Task<IQueryable<T>> GetAllAsNoTrackingAsync(IBaseSpecification<T> specification);

        #endregion Get All

        #region Find

        Task<T?> FindAsync(IBaseSpecification<T> specification);

        Task<T?> FindAsNoTrackingAsync(IBaseSpecification<T> specification);

        #endregion Find

        #region Add

        Task AddAsync(T entity);

        Task AddRangeAsync(ICollection<T> entities);

        #endregion Add

        #region Update

        Task UpdateAsync(T entity);

        Task UpdateRangeAsync(ICollection<T> entities);

        #endregion Update

        #region Remove

        Task RemoveAsync(T entity);

        Task RemoveRangeAsync(ICollection<T> entities);

        #endregion Remove

        #region Save

        Task<int> SaveChangesAsync();

        #endregion Save

        #region Transaction

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackTransactionAsync();

        #endregion Transaction
    }
}