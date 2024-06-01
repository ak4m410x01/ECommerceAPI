namespace ECommerceAPI.Application.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();

        Task<T?> GetById<TId>(TId id);
    }
}