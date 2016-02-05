namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Models
{
    public class OrderLine
    {
        public OrderLine()
        {

        }

        public OrderLine(long productId, string product, int quantity, decimal totalExclTax, decimal totalInclTax)
        {
            this.ProductId = productId;
            this.Product = product;
            this.Quantity = quantity;
            this.TotalExclTax = totalExclTax;
            this.TotalInclTax = totalInclTax;
        }

        public long ProductId { get; set; }

        public string Product { get; set; }

        public int Quantity { get; set; }

        public decimal TotalExclTax { get; set; }

        public decimal TotalInclTax { get; set; }
    }
}