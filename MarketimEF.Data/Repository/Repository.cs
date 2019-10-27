using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketimEF.Data.Repository
{
    //Generic Repository Pattern
    public class Repository<T> : IRepository<T> where T : class
    {
        private MarketimEntities db;

        public Repository()
        {
            db = new MarketimEntities();
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            return db.Set<T>().Any(predicate);
        }

        public bool Delete(int id)
        {
            var result = db.Set<T>().Find(id);
            db.Set<T>().Remove(result);
            return db.SaveChanges() > 0;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public T Get(int id)
        {
            return db.Set<T>().Find(id);
        }

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public int Save(T obj)
        {
            db.Set<T>().Add(obj);
            return db.SaveChanges();
        }

        public List<T> Search(Expression<Func<T, bool>> predicate)
        {
            //select * from T where column1= and/or column2=
            return db.Set<T>().Where(predicate).ToList();
        }

        public int Update(T obj)
        {
            db.Entry<T>(obj).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
