namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Order
    {
        public Order()
        {
            this.Lines = new List<OrderLine>();
        }

        public Order(long number, DateTime orderDate) : this()
        {
            this.Number = number;
            this.OrderDate = orderDate;
        }

        public long Number { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalExclTax
        {
            get
            {
                if (this.Lines == null)
                {
                    return 0;
                }

                return this.Lines.Sum(x => x.TotalExclTax);
            }
        }


        public decimal TotalInclTax
        {
            get
            {
                if (this.Lines == null)
                {
                    return 0;
                }

                return this.Lines.Sum(x => x.TotalInclTax);
            }
        }

        public List<OrderLine> Lines { get; set; }
    }
}