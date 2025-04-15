using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class OrderDetails
    {
        public int OrderId { get; set; }
        public int BasketID { get; set; }
        public string BasketName { get; set; }
        public int SKUID { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderBy { get; set; }
        public BasketMaster BasketMasters { get; set; }
        public List<BasketItemDetails> BasketItems { get; set; }
    }
}
