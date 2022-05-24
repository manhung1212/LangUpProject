using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LangUp.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<T> Create(T entity);
        Task<int> Update(T entity, int key);
        Task<int> Delete(T entity);
        Task<int> Save();
        Task<IEnumerable<T>> SQLCommand(string sql, string[] param);

    }
}
