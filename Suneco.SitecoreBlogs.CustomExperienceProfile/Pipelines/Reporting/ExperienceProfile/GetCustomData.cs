namespace Suneco.SitecoreBlogs.CustomExperienceProfile.Pipelines.Reporting.ExperienceProfile
{
    using System;
    using System.Data;
    using Extensions;
    using Services;
    using Sitecore.Cintel.Reporting;
    using Sitecore.Cintel.Reporting.Processors;

    public class GetCustomData : ReportProcessorBase
    {
        public enum CustomDataFields
        {
            ContactId = 0,
            Day = 1,
            Color = 2
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
            table.AddViewField<string>(CustomDataFields.ContactId.ToString());
            table.AddViewField<string>(CustomDataFields.Day.ToString());
            table.AddViewField<string>(CustomDataFields.Color.ToString());
        }

        private void PopulateData(DataTable table, Guid contactId)
        {
            var userdata = UserService.GetUserData(contactId);

            foreach (var customData in userdata)
            {
                var row = table.NewRow();

                row.SetField(CustomDataFields.ContactId.ToString(), customData.ContactId);
                row.SetField(CustomDataFields.Day.ToString(), customData.Day);
                row.SetField(CustomDataFields.Color.ToString(), customData.Color);

                table.Rows.Add(row);
            }
        }

    }
}