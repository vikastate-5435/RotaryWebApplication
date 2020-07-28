using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
  public class RotaryDbContext : DbContext
    {
        public RotaryDbContext()  : base("name=rotaryContext")
        {
        }
        public virtual DbSet<BasketMaster> BasketMasters { get; set; }
        public virtual DbSet<BasketItemDetails> BasketItemDetails { get; set; }
        public virtual DbSet<ProductMaster> Products { get; set; }
        public virtual DbSet<UnitMaster> Units { get; set; }

    }
}
