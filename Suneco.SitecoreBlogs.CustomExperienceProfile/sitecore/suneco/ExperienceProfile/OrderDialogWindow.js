define(["sitecore",
    "/-/speak/v1/experienceprofile/DataProviderHelper.js",
    "/-/speak/v1/experienceprofile/CintelUtl.js"
],
  function (sc, providerHelper, cintelUtil, ExternalDataApiVersion) {
      var app = sc.Definitions.App.extend({
          initialized: function () {
              sc.trigger("OrderDetailApp", this);
          },

          open: function (application, order) {
              var orderNumber = order.get("Number");

              // Get order data from order
              this.OrderNumberValue.set("text", orderNumber);
              this.OrderDateValue.set("text", order.get("Date"));

              this.setupOrderLines(sc.Contact.baseUrl + "/intel/", orderNumber);
          },

          setupOrderLines: function (intelBaseUrl, orderNumber) {
              var serviceName = "get-orderlines-data";
              providerHelper.initProvider(this.OrderLinesProvider, serviceName, intelBaseUrl + "/" + serviceName + "/" + orderNumber, this.CustomDataMessageBar);
              providerHelper.getListData(this.OrderLinesProvider);
          }
      });

      return app;
  });