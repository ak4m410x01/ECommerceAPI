namespace ECommerceAPI.Domain.Entities.Products
{
    public class ProductTag
    {
        #region Relationships
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public int TagId { get; set; }
        public Tag? Tag { get; set; }
        #endregion
    }
}
