using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Basket")]
        public int? BasketID { get; set; }

        [DisplayName("Product Id")]
        public int ProductID { get; set; }

        [DisplayName("Product")]
        [StringLength(200)]
        public string ProductName { get; set; }

        [StringLength(100)]
        public string SKU { get; set; }

        [DisplayName("Applicable From")]
        [DataType(DataType.DateTime)]
        public DateTime ApplicableFrom { get; set; }

        [DisplayName("Applicable To")]
        [DataType(DataType.DateTime)]
        public DateTime ApplicableTo { get; set; }
        public int Quantity { get; set; }
        public decimal KG { get; set; }

        [ForeignKey("BasketID")]
        public BasketMaster BasketMasters { get; set; }


    }
}
