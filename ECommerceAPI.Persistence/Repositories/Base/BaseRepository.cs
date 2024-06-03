using ECommerceAPI.Application.Interfaces.Repositories.Base;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Persistence.DbContexts;
using ECommerceAPI.Persistence.Specifications.Evaluations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ECommerceAPI.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Properties

        protected readonly ApplicationDbContext _context;

        #endregion Properties

        #region Constructors

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Constructors

        #region Method

        protected virtual DbSet<T> GetDbSet()
        {
            return _context.Set<T>();
        }

        protected virtual IQueryable<T> GetQuery(IBaseSpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(GetDbSet(), specification);
        }

        #region Get All

        public virtual Task<IQueryable<T>> GetAllAsync(IBaseSpecification<T> specification)
        {
            return Task.FromResult(GetQuery(specification));
        }

        public virtual Task<IQueryable<T>> GetAllAsNoTrackingAsync(IBaseSpecification<T> specification)
        {
            return Task.FromResult(GetQuery(specification).AsNoTracking());
        }

        #endregion Get All

        #region Find

        public virtual Task<T?> FindAsync(IBaseSpecification<T> specification)
        {
            return GetQuery(specification).FirstOrDefaultAsync();
        }

        public virtual Task<T?> FindAsNoTrackingAsync(IBaseSpecification<T> specification)
        {
            return GetQuery(specification).AsNoTracking().FirstOrDefaultAsync();
        }

        #endregion Find

        #region Add

        public virtual async Task AddAsync(T entity)
        {
            await GetDbSet().AddAsync(entity);
            await SaveChangesAsync();
        }

        public virtual async Task AddRangeAsync(ICollection<T> entities)
        {
            await GetDbSet().AddRangeAsync(entities);
            await SaveChangesAsync();
        }

        #endregion Add

        #region Update

        public virtual async Task UpdateAsync(T entity)
        {
            GetDbSet().Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateRangeAsync(ICollection<T> entities)
        {
            GetDbSet().UpdateRange(entities);
            await SaveChangesAsync();
        }

        #endregion Update

        #region Remove

        public virtual async Task RemoveAsync(T entity)
        {
            GetDbSet().Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task RemoveRangeAsync(ICollection<T> entities)
        {
            GetDbSet().RemoveRange(entities);
            await SaveChangesAsync();
        }

        #endregion Remove

        #region Save

        public virtual async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        #endregion Save

        #region Transaction

        public virtual async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public virtual async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public virtual async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        #endregion Transaction

        #endregion Method
    }
}