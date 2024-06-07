namespace ECommerceAPI.Application.Features.Product.Discounts.Commands.AddDiscount.DTOs
{
    public class AddDiscountCommandDTO
    {
        #region Properties

        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal Percent { get; set; }
        public int UsedTimes { get; set; }
        public int MaxUses { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public DateTime CreatedAt { get; set; }

        #endregion Properties
    }
}