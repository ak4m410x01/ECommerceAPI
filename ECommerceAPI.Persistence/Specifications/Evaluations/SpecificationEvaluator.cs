using ECommerceAPI.Application.Interfaces.Specifications.Base;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Specifications.Evaluations
{
    public static class SpecificationEvaluator<T> where T : class
    {
        #region Methods

        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            IQueryable<T> query = inputQuery;

            query = AddCriteria(query, specification);

            query = AddIncludes(query, specification);

            query = AddOrderBy(query, specification);

            return query;
        }

        private static IQueryable<T> AddCriteria(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            return specification.Criteria is null ? inputQuery : inputQuery.Where(specification.Criteria);
        }

        private static IQueryable<T> AddIncludes(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            return specification.Includes
                                .Aggregate(inputQuery,
                                        (current, expression) => current.Include(expression));
        }

        private static IQueryable<T> AddOrderBy(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            if (specification.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderByDescending(specification.OrderByDescending);
            }

            return inputQuery;
        }

        #endregion Methods
    }
}