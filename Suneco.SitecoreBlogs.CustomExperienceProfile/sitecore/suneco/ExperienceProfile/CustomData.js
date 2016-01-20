define(["sitecore",
    "/-/speak/v1/experienceprofile/DataProviderHelper.js",
    "/-/speak/v1/experienceprofile/CintelUtl.js"
],
  function (sc, providerHelper, cintelUtil, ExternalDataApiVersion) {
      var intelPath = "/intel";
      var customDataTable = "custom-data";

      var app = sc.Definitions.App.extend({
          initialized: function () {
              $('.sc-progressindicator').first().show().hide();

              var intelBaseUrl = sc.Contact.baseUrl + intelPath + "/";

              this.setupCustomData(intelBaseUrl, customDataTable);
          },

          setupCustomData: function (intelBaseUrl, table) {
              providerHelper.initProvider(this.CustomDataProvider, table, intelBaseUrl + table, this.CustomDataMessageBar);
              providerHelper.getListData(this.CustomDataProvider);
          },
      });
      return app;
  });