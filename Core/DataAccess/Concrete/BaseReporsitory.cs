using Core.DataAccess.Abstract;
using Core.Entity.Abstract;
using Core.Helper.Results.Abstract;
using Core.Helper.Results.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class BaseReporsitory<TEntity, TContext> : IBaseReporsitory<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using TContext contex = new TContext();
            var addEntity = contex.Entry(entity);
            addEntity.State = EntityState.Added;
            contex.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            using TContext contex = new TContext();
            var deleteEntity = contex.Entry(entity);
            deleteEntity.State = EntityState.Modified;
            contex.SaveChanges();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new TContext();
            return context.Set<TEntity>().SingleOrDefault(filter);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            using TContext context = new TContext();
            return filter != null ? context.Set<TEntity>().Where(filter).ToList() : context.Set<TEntity>().ToList();
        }

        public void Update(TEntity entity)
        {
            using TContext contex = new TContext();
            var updateEntity = contex.Entry(entity);
            updateEntity.State = EntityState.Modified;
            contex.SaveChanges();
        }
    }
}
