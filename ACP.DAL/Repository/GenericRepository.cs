using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACP.DAL.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class, new()
    {
        DbContext context;
        IDbSet<T> dbSet;

        public GenericRepository(DbContext c)
        {
            context = c;
            dbSet = context.Set<T>();
        }


        public IEnumerable<T> GetAll() => dbSet;

        public T Get(int id) => dbSet.Find(id);

        public IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate) => dbSet.Where(predicate);


        public void AddOrUpdate(T obj)
        {
            try
            {
                dbSet.AddOrUpdate(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Delete(T obj)
        {
            try
            {
                dbSet.Remove(obj);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
         
        public int Save()
        {
            try
            {
                return context.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}

