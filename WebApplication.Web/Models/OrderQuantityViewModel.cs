using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Web.Models
{
    public class OrderQuantityViewModel
    {
        [DisplayName("Product Id")]
        public int ProductID { get; set; }

        [DisplayName("Product Name")]
        [StringLength(200)]
        public string ProductName { get; set; }
        [StringLength(100)]
        public int SKU { get; set; }
        public int Quantity { get; set; }
        public decimal KG { get; set; }

    }
}