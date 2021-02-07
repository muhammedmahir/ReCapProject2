using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //using bittiği anda belleği temizlemek için bu yapıyı kullanıyoruz.
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity); // referansı al
                addedEntity.State = EntityState.Added; // atama yap
                context.SaveChanges();//kaydet
            }
        }

        public void Delete(TEntity entity)
        {
            //using bittiği anda belleği temizlemek için bu yapıyı kullanıyoruz.
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity); // referansı al
                deletedEntity.State = EntityState.Deleted; // atama yap
                context.SaveChanges();//kaydet
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
                // Car tablosunu select et ve liste olarak ver.
            }
        }

        public void Update(TEntity entity)
        {
            //using bittiği anda belleği temizlemek için bu yapıyı kullanıyoruz.
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity); // referansı al
                updatedEntity.State = EntityState.Modified; // atama yap
                context.SaveChanges();//kaydet
            }
        }
    }
}
