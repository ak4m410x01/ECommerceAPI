using ECommerceAPI.Application.Interfaces.Repositories.Base;
using ECommerceAPI.Application.Interfaces.Specifications.Base;
using ECommerceAPI.Persistence.DbContexts;
using ECommerceAPI.Persistence.Specifications.Evaluations;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        #region Properties

        private readonly ApplicationDbContext _context;

        #endregion Properties

        #region Constructors

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion Constructors

        #region Method

        private IQueryable<T> GetQuery(IBaseSpecification<T> specification)
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
        }

        public Task<IQueryable<T>> GetAllAsync(IBaseSpecification<T> specification)
        {
            return Task.FromResult(GetQuery(specification).AsNoTracking());
        }

        public Task<T?> FindAsync(IBaseSpecification<T> specification)
        {
            return GetQuery(specification).FirstOrDefaultAsync();
        }

        #endregion Method
    }
}