namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Services
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Suneco.SitecoreBlogs.CustomExperienceProfile.Models;

    public class ShopService
    {
        public static IList<Order> GetOrders(Guid contactId)
        {
            var data = new List<Order>();

            data.Add(new Order(20160101001, DateTime.Now)
                {
                    Lines = new List<OrderLine>()
                    {
                        new OrderLine(1, "ProductId", 1, 100, 110),
                        new OrderLine(2, "ProductId", 2, 400, 440),
                    }
                });
            data.Add(new Order(20160101002, DateTime.Now)
            {
                Lines = new List<OrderLine>()
                    {
                        new OrderLine(1, "ProductId", 2, 200, 220),
                        new OrderLine(2, "ProductId", 2, 400, 440),
                        new OrderLine(3, "ProductId", 3, 600, 660),
                    }
            });

            return data;
        }

        public static Order GetOrder(Guid contactId, long orderNumber)
        {
            return GetOrders(contactId).FirstOrDefault(x => x.Number == orderNumber);
        }
    }
}

