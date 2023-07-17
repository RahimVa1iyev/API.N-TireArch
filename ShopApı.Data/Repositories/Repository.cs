using Microsoft.EntityFrameworkCore;
using ShopApi.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApi.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ShopDbContext _context;

        public Repository(ShopDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity brand)
        {
            _context.Set<TEntity>().Add(brand);
        }

        public void Delete(TEntity brand)
        {

            _context.Set<TEntity>().Remove(brand);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> exp , params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includes!=null && includes.Length >0)
            {
                foreach (var item in includes)
                {
                   query = query.Include(item);
                }
            }

             return query.FirstOrDefault(exp);
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> exp , params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                   query = query.Include(item);
                }
            }

            return query.Where(exp);
        }

        public int IsCommit()
        {
            return _context.SaveChanges();
        }

        public bool IsExist(Expression<Func<TEntity, bool>> exp, params string[] includes)
        {
            var query = _context.Set<TEntity>().AsQueryable();

            if (includes != null && includes.Length > 0)
            {
                foreach (var item in includes)
                {
                   query = query.Include(item);
                }
            }

            return query.Any(exp);
        }
    }
}
