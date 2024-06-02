using System.Linq.Expressions;

namespace ECommerceAPI.Application.Interfaces.Specifications.Base
{
    public interface IBaseSpecification<T> where T : class
    {
        Expression<Func<T, bool>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
    }
}