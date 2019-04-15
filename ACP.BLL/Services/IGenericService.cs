using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ACP.BLL.Services
{
    public interface IGenericService<T> where T : class, new() 
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T, bool>> predicate);
        T Get(int id);
        T Add(T obj);
        T Update(T obj);
        T Delete(T obj);
        T Delete(int id);
    }
}
