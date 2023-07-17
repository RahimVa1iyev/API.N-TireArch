using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Core.Entities
{
    public class BaseTracker : BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}
