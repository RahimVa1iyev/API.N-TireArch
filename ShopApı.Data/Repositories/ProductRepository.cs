using ShopApi.Core.Entities;
using ShopApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Data.Repositories
{
    public class ProductRepository :Repository<Product> , IProductRepository
    {
        public ProductRepository(ShopDbContext context) : base(context)
        {

        }

    }
}
