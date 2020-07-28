using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class BasketMaster
    {
        [Key]
        public int BasketID { get; set; }
        public string BasketName { get; set; }
        public int SKUID { get; set; }
    }
}
