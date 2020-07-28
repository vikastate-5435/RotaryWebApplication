using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
   public class UnitMaster
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int KG { get; set; }

        [StringLength(100)]
        public string UnitName { get; set; }
    }
}
