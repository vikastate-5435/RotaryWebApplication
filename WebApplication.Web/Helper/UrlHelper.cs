using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Web.Helper
{
    public class URLHelper
    {
        public static class Common
        {
            public static string DeletePartialURL = "~/Views/Shared/_Delete.cshtml";
            public static string InsertUpdatePartialURL = "_InsertUpdate";
        }

        public static class BasketOrder
        {
            public static string BasketOrderTableId = "BasketOrderTable";
            public static string BasketOrderModalId = "BasketOrderModal";
            public static string BasketOrderListUrl = "LoadBasketOrderList";
            public static string BasketOrderDeleteURL = "BasketOrder/BasketOrder/DeleteBasketOrder/";
        }

    }
}