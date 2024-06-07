namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetAllInventories.DTOs
{
    public class GetAllInventoriesQueryDTO
    {
        #region Properties

        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}