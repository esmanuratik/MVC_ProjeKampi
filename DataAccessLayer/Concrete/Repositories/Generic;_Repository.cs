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
    public class Generic__Repository<T> : IRepository<T> where T : class
    {
        Context c=new Context();
        DbSet<T> _object;
        public Generic__Repository()
        {
            _object=c.Set<T>();//contexte bağlı olarak gönderdiğim T değeri
            //_object e atama yapailmek için ctor oluşturuldu.
        }
        public void Delete(T p)
        {
            var deletedEntity =c.Entry(p);
            deletedEntity.State = EntityState.Deleted;
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
           return _object.SingleOrDefault(filter);//tek bir değer tutacağı için singleordefault kull.   
        }

        public void Insert(T p)
        {
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added;
            // _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();    
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updatedEntity = c.Entry(p);
            updatedEntity.State= EntityState.Modified;
            c.SaveChanges();
        }
    }
}
