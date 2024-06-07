namespace ECommerceAPI.Application.Features.Product.Discounts.Queries.GetAllDiscounts.DTOs
{
    public class GetAllDiscountsQueryDTO
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Description { get; set; }
        public decimal Percent { get; set; }
        public int UsedTimes { get; set; }
        public int MaxUses { get; set; }
        public DateTime StartAt { get; set; }
        public DateTime EndAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}