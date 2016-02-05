define(["sitecore",
    "/-/speak/v1/experienceprofile/DataProviderHelper.js",
    "/-/speak/v1/experienceprofile/CintelUtl.js"
],
  function (sc, providerHelper, cintelUtil, ExternalDataApiVersion) {
      var selectedItemIdProperty = "selectedItemId";
      var orderDialogApp;

      var app = sc.Definitions.App.extend({
          initialized: function () {
              $('.sc-progressindicator').first().show().hide();

              sc.on("OrderDetailApp", function (subapp) {
                  orderDialogApp = subapp;
              }, this);

              sc.Order = {
                  subscribeOrderDialog: function (listControl, panel, popup) {
                      listControl.on("change:" + selectedItemIdProperty, function () {
                          if (!listControl.get(selectedItemIdProperty)) return;
                          this.openOrderDialog(listControl.get("selectedItem"), panel, popup);
                          listControl.set(selectedItemIdProperty, null);
                      }, this);
                  },

                  openOrderDialog: function (order, panel, popup) {
                      panel.set("isLoaded", false);
                      panel.refresh();

                      panel.set("isBusy", true);
                      popup.show();

                      panel.on("change:isLoaded", function () {
                          panel.off("change:isLoaded");
                          panel.set("isBusy", false);

                          alert('test');

                          orderDialogApp.open(orderDialogApp, order);

                      }, this);
                  }
              };

              this.setupOrders(sc.Contact.baseUrl + "/intel/", "get-orders-data");

              sc.Order.subscribeOrderDialog(this.OrdersListControl, this.OrderDialogLoadOnDemandPanel, this.OrderDialogWindow);
          },

          setupOrders: function (intelBaseUrl, table) {
              providerHelper.initProvider(this.OrdersProvider, table, intelBaseUrl + table, this.CustomDataMessageBar);
              providerHelper.getListData(this.OrdersProvider);
          },
      });
      return app;
  });