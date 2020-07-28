using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class BasketItemDetails
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int BasketID { get; set; }

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

        public decimal KG { get; set; }
       
    }
}
