using System;
using System.Collections.Generic;
using Suneco.SitecoreBlogs.CustomExperienceProfile.Models;

namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Services
{
    public class UserService
    {
        public static IList<CustomData> GetUserData(Guid contactId)
        {
            var data = new List<CustomData>();

            data.Add(new CustomData(contactId, DayOfWeek.Sunday, System.Drawing.Color.White));
            data.Add(new CustomData(contactId, DayOfWeek.Monday, System.Drawing.Color.Yellow));
            data.Add(new CustomData(contactId, DayOfWeek.Tuesday, System.Drawing.Color.Red));
            data.Add(new CustomData(contactId, DayOfWeek.Wednesday, System.Drawing.Color.Green));
            data.Add(new CustomData(contactId, DayOfWeek.Thursday, System.Drawing.Color.Black));
            data.Add(new CustomData(contactId, DayOfWeek.Friday, System.Drawing.Color.Blue));
            data.Add(new CustomData(contactId, DayOfWeek.Saturday, System.Drawing.Color.Gray));

            return data;
        }
    }
}