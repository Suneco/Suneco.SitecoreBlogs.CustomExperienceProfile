﻿namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Pipelines.Reporting.ExperienceProfile
{
    using System;
    using System.Data;
    using Extensions;
    using Services;
    using Sitecore.Cintel.Reporting;
    using Sitecore.Cintel.Reporting.Processors;

    public class GetOrderData : ReportProcessorBase
    {
        public enum OrderFields
        {
            Number = 0,
            Date = 1,
            TotalExclTax = 2,
            TotalInclTax = 3
        }

        public override void Process(ReportProcessorArgs args)
        {
            var result = args.QueryResult;
            args.ResultTableForView = new DataTable();

            this.InitializeDataTable(args.ResultTableForView);
            this.PopulateData(args.ResultTableForView, args.ReportParameters.ContactId);

            args.ResultSet.Data.Dataset[args.ReportParameters.ViewName] = args.ResultTableForView;
        }

        private void InitializeDataTable(DataTable table)
        {
            table.AddViewField<long>(OrderFields.Number.ToString());
            table.AddViewField<string>(OrderFields.Date.ToString());
            table.AddViewField<decimal>(OrderFields.TotalExclTax.ToString());
            table.AddViewField<decimal>(OrderFields.TotalInclTax.ToString());
        }

        private void PopulateData(DataTable table, Guid contactId)
        {
            var orders = ShopService.GetOrders(contactId);

            foreach (var order in orders)
            {
                var row = table.NewRow();

                row.SetField(OrderFields.Number.ToString(), order.Number);
                row.SetField(OrderFields.Date.ToString(), order.OrderDate);
                row.SetField(OrderFields.TotalExclTax.ToString(), order.TotalExclTax);
                row.SetField(OrderFields.TotalInclTax.ToString(), order.TotalInclTax);

                table.Rows.Add(row);
            }
        }
    }
}