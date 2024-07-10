namespace ECommerceAPI.Application.Features.Product.Inventories.Commands.UpdateInventory.DTOs
{
    public class UpdateInventoryCommandDTO
    {
        #region Properties

        public int Id { get; set; }
        public int Quantity { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}