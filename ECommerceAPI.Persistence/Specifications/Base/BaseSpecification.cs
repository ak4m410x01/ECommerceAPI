using ECommerceAPI.Application.Interfaces.Specifications.Base;
using System.Linq.Expressions;

namespace ECommerceAPI.Persistence.Specifications.Base
{
    public class BaseSpecification<T> : IBaseSpecification<T> where T : class
    {
        #region Fields

        public Expression<Func<T, object>>? _orderBy;
        public Expression<Func<T, object>>? _orderByDescending;

        #endregion Fields

        #region Constructors

        public BaseSpecification()
        {
        }

        #endregion Constructors

        #region Properties

        public Expression<Func<T, bool>>? Criteria { get; set; }
        public List<Expression<Func<T, object>>> Includes { get; } = new();

        public Expression<Func<T, object>>? OrderBy
        {
            get
            {
                return _orderBy;
            }
            set
            {
                _orderBy = value;
            }
        }

        public Expression<Func<T, object>>? OrderByDescending
        {
            get
            {
                return _orderByDescending;
            }
            set
            {
                _orderByDescending = value;
            }
        }

        #endregion Properties

        #region Methods

        public virtual void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        #endregion Methods
    }
}