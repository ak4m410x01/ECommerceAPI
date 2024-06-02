using ECommerceAPI.Application.Interfaces.Repositories.Base;
using ECommerceAPI.Application.Interfaces.UnitOfWork;
using ECommerceAPI.Persistence.DbContexts;
using ECommerceAPI.Persistence.Repositories.Base;
using System.Collections.Concurrent;

namespace ECommerceAPI.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Properties

        private readonly ApplicationDbContext _context;

        private ConcurrentDictionary<string, object> _repositories;

        #endregion Properties

        #region Constructors

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        #endregion Constructors

        #region Methods

        public IBaseRepository<T> Repository<T>() where T : class
        {
            string type = typeof(T).Name;

            BaseRepository<T> repository = new(_context);

            return (IBaseRepository<T>)_repositories.GetOrAdd(type, repository);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        #endregion Methods
    }
}