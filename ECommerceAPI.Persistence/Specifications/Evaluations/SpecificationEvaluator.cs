using ECommerceAPI.Application.Interfaces.Specifications.Base;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Specifications.Evaluations
{
    public static class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, IBaseSpecification<T> specification)
        {
            IQueryable<T> query = inputQuery;

            query = AddCriteria(query, specification);

            query = AddIncludes(query, specification);

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
    }
}