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

        public Expression<Func<T, bool>> Criteria { get; set; } = default!;
        public List<Expression<Func<T, object>>> Includes { get; } = new();

        #endregion Properties

        #region Methods

        protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        #endregion Methods
    }
}