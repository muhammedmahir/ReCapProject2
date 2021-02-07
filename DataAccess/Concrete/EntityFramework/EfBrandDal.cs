using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    class EfBrandDal : ICarDal
    {
        public void Add(Car entity)
        {
            //using bittiği anda belleği temizlemek için bu yapıyı kullanıyoruz.
            using (CarContext context = new CarContext())
            {
                var addedEntity = context.Entry(entity); // referansı al
                addedEntity.State = EntityState.Added; // atama yap
                context.SaveChanges();//kaydet
            }
        }

        public void Delete(Car entity)
        {
            //using bittiği anda belleği temizlemek için bu yapıyı kullanıyoruz.
            using (CarContext context = new CarContext())
            {
                var deletedEntity = context.Entry(entity); // referansı al
                deletedEntity.State = EntityState.Deleted; // atama yap
                context.SaveChanges();//kaydet
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarContext context = new CarContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarContext context = new CarContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
                    // Car tablosunu select et ve liste olarak ver.
            }
        }

        public void Update(Car entity)
        {
            //using bittiği anda belleği temizlemek için bu yapıyı kullanıyoruz.
            using (CarContext context = new CarContext())
            {
                var updatedEntity = context.Entry(entity); // referansı al
                updatedEntity.State = EntityState.Modified; // atama yap
                context.SaveChanges();//kaydet
            }
        }
    }
}
