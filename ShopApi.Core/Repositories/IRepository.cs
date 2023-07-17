using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Core.Repositories
{
    public interface IRepository<TEntity>
    {

        void Add(TEntity brand);

        void Delete(TEntity brand);

        TEntity Get(Expression<Func<TEntity, bool>> exp,params string[] includes);

        bool IsExist(Expression<Func<TEntity, bool>> exp , params string[] includes);

        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> exp ,params string[] icludes);

        int IsCommit();
    }
}
