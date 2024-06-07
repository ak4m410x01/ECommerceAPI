namespace ECommerceAPI.Shared.Responses
{
    public class PaginatedRequest
    {
        #region Properties

        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        #endregion Properties
    }
}