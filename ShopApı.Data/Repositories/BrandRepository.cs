using ShopApi.Core.Entities;
using ShopApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Data.Repositories
{
    public class BrandRepository : Repository<Brand> , IBrandRepository
    {
        public BrandRepository(ShopDbContext context) : base(context)
        {

        }
    }
}
