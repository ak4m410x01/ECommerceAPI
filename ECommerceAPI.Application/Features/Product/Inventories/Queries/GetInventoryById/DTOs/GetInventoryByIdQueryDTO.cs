namespace ECommerceAPI.Application.Features.Product.Inventories.Queries.GetInventoryById.DTOs
{
    public class GetInventoryByIdQueryDTO
    {
        #region Properties

        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}