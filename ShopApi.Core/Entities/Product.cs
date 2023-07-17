using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Core.Entities
{
    public class Product : BaseTracker
    {
        public int BrandId { get; set; }

        public string Name { get; set; }

        public decimal SalePrice { get; set; }

        public decimal CostPrice { get; set; }

        public Brand Brand { get; set; }
    }
}
