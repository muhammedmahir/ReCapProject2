using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    //generic constraint 
    //class: referans tip kısıtı veriyor.
    //IEntity kısıtı: IEntity veya onun bir alt nesne olabilir
    //new: nevlenebilir bir nesne olmalı.
    public interface IEntityRepository<T> where T:class,IEntity, new()
    {
        //Expression yapısı bizim filtre verebilmemizi sağlıyor. 
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
