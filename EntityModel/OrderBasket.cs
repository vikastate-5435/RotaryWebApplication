using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class OrderBasket
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }
        public int BasketID { get; set; }

        [StringLength(250)]
        public string BasketName { get; set; }
        public int SKUID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime OrderDate { get; set; }

        [StringLength(250)]
        public string OrderBy { get; set; }


    }

}
