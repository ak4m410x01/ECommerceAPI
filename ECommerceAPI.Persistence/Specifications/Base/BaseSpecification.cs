using ECommerceAPI.Application.Interfaces.Specifications.Base;
using System.Linq.Expressions;

namespace ECommerceAPI.Persistence.Specifications.Base
{
    public class BaseSpecification<T> : IBaseSpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Expression<Func<T, object>>> Includes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}