namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Models
{
    using System;
    using System.Drawing;

    public class Order
    {
        public Order()
        {

        }

        public Order(long number, DateTime orderDate, decimal totalExclTax, decimal totalInclTax) : this()
        {
            this.Number = number;
            this.OrderDate = orderDate;
            this.TotalExclTax = totalExclTax;
            this.TotalInclTax = totalInclTax;
        }

        public long Number { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalInclTax { get; set; }

        public decimal TotalExclTax { get; set; }
    }
}