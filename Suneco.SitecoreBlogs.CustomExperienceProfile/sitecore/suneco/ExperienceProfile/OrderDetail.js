define(["sitecore",
    "/-/speak/v1/experienceprofile/DataProviderHelper.js",
    "/-/speak/v1/experienceprofile/CintelUtl.js"
],
  function (sc, providerHelper, cintelUtil, ExternalDataApiVersion) {
      var intelPath = "/intel";
      var ordersTable = "get-orders-data";

      var app = sc.Definitions.App.extend({
          initialized: function () {
              $('.sc-progressindicator').first().show().hide();

              var intelBaseUrl = sc.Contact.baseUrl + intelPath + "/";

              this.setupOrders(intelBaseUrl, ordersTable);
          },

          setupOrders: function (intelBaseUrl, table) {
              providerHelper.initProvider(this.OrdersProvider, table, intelBaseUrl + table, this.CustomDataMessageBar);
              providerHelper.getListData(this.OrdersProvider);
          },
      });
      return app;
  });