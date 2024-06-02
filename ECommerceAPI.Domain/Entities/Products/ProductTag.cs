namespace ECommerceAPI.Domain.Entities.Products
{
    public class ProductTag
    {
        #region Relationships

        public int ProductId { get; set; }
        public virtual Product? Product { get; set; }
        public int TagId { get; set; }
        public virtual Tag? Tag { get; set; }

        #endregion Relationships
    }
}