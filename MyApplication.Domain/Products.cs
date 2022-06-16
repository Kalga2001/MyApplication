namespace MyApplication.Domain
{
    public class Products : BaseEntity
    {
        public string ProductName { get; set; }
        public ICollection<ProductOffers> ProductOffers { get; set; }
        public int ProductId { get; set; }
    }
}