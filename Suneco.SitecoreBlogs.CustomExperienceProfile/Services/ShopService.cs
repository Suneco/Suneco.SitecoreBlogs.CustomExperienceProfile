using System;
using System.Collections.Generic;
using Suneco.SitecoreBlogs.CustomExperienceProfile.Models;

namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Services
{
    public class ShopService
    {
        public static IList<Order> GetOrders(Guid contactId)
        {
            var data = new List<Order>();

            data.Add(new Order(20160101001, DateTime.Now, 111, 123));
            data.Add(new Order(20160101002, DateTime.Now, 100, 111));
            data.Add(new Order(20160101003, DateTime.Now, 999, 1200));
            data.Add(new Order(20160101004, DateTime.Now, 34, 50));
            data.Add(new Order(20160102001, DateTime.Now, 267, 300));
            data.Add(new Order(20160102002, DateTime.Now, 100, 106));
            data.Add(new Order(20160102003, DateTime.Now, 2000, 2200));

            return data;
        }
    }
}