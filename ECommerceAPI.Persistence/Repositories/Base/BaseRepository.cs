using ECommerceAPI.Application.Interfaces.Repositories.Base;
using ECommerceAPI.Persistence.DbContexts;
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

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_context.Set<T>().AsNoTracking());
        }

        public async Task<T?> GetById<TId>(TId id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        #endregion Method
    }
}