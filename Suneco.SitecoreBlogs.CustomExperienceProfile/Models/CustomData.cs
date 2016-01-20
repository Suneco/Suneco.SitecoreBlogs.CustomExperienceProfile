namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Models
{
    using System;
    using System.Drawing;

    public class CustomData
    {
        public CustomData()
        {

        }

        public CustomData(Guid contactId, DayOfWeek day, Color color) : this()
        {
            this.ContactId = contactId;
            this.Day = day;
            this.Color = color;
        }

        public Guid ContactId { get; set; }

        public DayOfWeek Day { get; set; }

        public Color Color { get; set; }



    }
}