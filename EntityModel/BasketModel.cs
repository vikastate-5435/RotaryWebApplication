using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class BasketModel
    {

        public int BasketID { get; set; }
        public string BasketName { get; set; }
        public int SKUID { get; set; }

        public int ProductID { get; set; }
        [StringLength(100)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string SKU { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ApplicableFrom { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ApplicableTo { get; set; }
        public int Quantity { get; set; }
        public int KG { get; set; }

    }
}
