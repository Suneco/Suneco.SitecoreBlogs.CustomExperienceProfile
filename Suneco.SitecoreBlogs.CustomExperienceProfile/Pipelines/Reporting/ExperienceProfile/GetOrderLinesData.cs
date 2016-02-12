namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Pipelines.Reporting.ExperienceProfile
{
    using System;
    using System.Data;
    using Extensions;
    using Services;
    using Sitecore.Cintel.Reporting;
    using Sitecore.Cintel.Reporting.Processors;

    public class GetOrderLinesData : ReportProcessorBase
    {
        public enum OrderLineFields
        {
            ProductId = 0,
            Product = 1,
            Quantity = 2,
            TotalExclTax = 3,
            TotalInclTax = 4
        }

        public override void Process(ReportProcessorArgs args)
        {
            var result = args.QueryResult;
            args.ResultTableForView = new DataTable();

            this.InitializeDataTable(args.ResultTableForView);

            long orderNumber;
            
            if (long.TryParse(args.ReportParameters.ViewEntityId, out orderNumber))
            {
                this.PopulateData(args.ResultTableForView, args.ReportParameters.ContactId, orderNumber);

                args.ResultSet.Data.Dataset[args.ReportParameters.ViewName] = args.ResultTableForView;
            }
        }

        private void InitializeDataTable(DataTable table)
        {
            table.AddViewField<long>(OrderLineFields.ProductId.ToString());
            table.AddViewField<string>(OrderLineFields.Product.ToString());
            table.AddViewField<int>(OrderLineFields.Quantity.ToString());
            table.AddViewField<decimal>(OrderLineFields.TotalExclTax.ToString());
            table.AddViewField<decimal>(OrderLineFields.TotalInclTax.ToString());
        }

        private void PopulateData(DataTable table, Guid contactId, long orderNumber)
        {
            var order = ShopService.GetOrder(contactId, orderNumber);

            foreach (var orderline in order.Lines)
            {
                var row = table.NewRow();

                row.SetField(OrderLineFields.ProductId.ToString(), orderline.ProductId);
                row.SetField(OrderLineFields.Product.ToString(), orderline.Product);
                row.SetField(OrderLineFields.Quantity.ToString(), orderline.Quantity);
                row.SetField(OrderLineFields.TotalExclTax.ToString(), orderline.TotalExclTax);
                row.SetField(OrderLineFields.TotalInclTax.ToString(), orderline.TotalInclTax);

                table.Rows.Add(row);
            }
        }

    }
}