namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Extensions
{
    using System.Data;
    using Sitecore.Cintel.Reporting;
    using Sitecore.Diagnostics;

    /// <summary>
    /// Custom extensions for the System.DataTable object
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Adds the column.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataTable">The data table.</param>
        /// <param name="columnName">Name of the column.</param>
        public static void AddViewField<T>(this DataTable dataTable, string columnName)
        {
            Assert.IsNotNull(dataTable, "dataTable");
            Assert.IsNotNullOrEmpty(columnName, "columnName");

            var viewField = new ViewField<T>(columnName);
            dataTable.Columns.Add(viewField.ToColumn());
        }
    }
}