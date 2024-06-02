using ECommerceAPI.Application.Interfaces.Specifications.Base;
using System.Linq.Expressions;

namespace ECommerceAPI.Persistence.Specifications.Base
{
    public class BaseSpecification<T> : IBaseSpecification<T> where T : class
    {
        #region Constructors

        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }

        #endregion Constructors

        #region Properties

        public Expression<Func<T, bool>> Criteria { get; }
        public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

        #endregion Properties
    }
}