using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context(); //veritabanı islemlerinin halledildiği bir sınıftır.
        DbSet<T> _object; //tablo olusturur.
        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var deletedEntity = c.Entry(p); //entry komutu ile context veritabanındaki ilgili tablonun degerinin durumu hakkında bilgi alınır.
            deletedEntity.State = EntityState.Deleted; //silinir.
            c.SaveChanges(); // ve degisiklikler kaydedilir.
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter);
        }

        public void insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> list()
        {
            return _object.ToList();
        }

        public List<T> list(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
