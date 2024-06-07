using ECommerceAPI.Shared.Responses;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Application.Extensions.Responses
{
    public static class QueryableExtensions
    {
        public static async Task<PaginatedResponse<T>> ToPaginatedQueryableAsync<T>(this IQueryable<T> source, int pageNumber, int pageSize)
        {
            int totalRecords = await source.CountAsync();

            pageNumber = pageNumber <= 0 ? 1 : pageNumber;
            pageSize = pageSize <= 0 ? 10 : pageSize;

            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return PaginatedResponse<T>.Create(items, totalRecords, pageNumber, pageSize);
        }
    }
}