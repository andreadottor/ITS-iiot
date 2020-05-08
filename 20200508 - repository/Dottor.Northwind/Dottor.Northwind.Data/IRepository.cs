using Dottor.Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dottor.Northwind.Data
{
    public interface IRepository<TEntity, TKey> 
                    where TEntity: EntityBase<TKey>
    {

        IEnumerable<TEntity> GetAll();

        TEntity Get(TKey id);

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TKey id);

        int Count();


    }
}
