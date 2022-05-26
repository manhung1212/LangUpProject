using Microsoft.EntityFrameworkCore;
using SampleWebApiAspNetCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LangUp.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbSet<T> _dbset;
        private readonly LangUpDbContext _entities;
        public GenericRepository()
        {
            this._entities = new LangUpDbContext();
            _dbset = _entities.Set<T>();
        }
        public GenericRepository(LangUpDbContext _context)
        {
            this._entities = _context;
            _dbset = _context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            _dbset.Add(entity);
            await Save();
            return entity;
        }

        public async Task<int> Delete(T entity)
        {
            _dbset.Remove(entity);
            return await Save();
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => (IEnumerable<T>)_dbset.Where(predicate).AsEnumerable());
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await Task.Run(() => _dbset.AsEnumerable<T>());
        }

        public async Task<int> Save()
        {
            try
            {
                return await _entities.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return -1;
                //return _entities.Commit();
            }
        }

        public  async Task<IEnumerable<T>> SQLCommand(string sql, string[] param)
        {
            return await Task.Run(() => _dbset.FromSqlRaw(sql, param).AsEnumerable<T>());
        }

        public async Task<int> Update(T entity, Guid key)
        {
            T existing = _entities.Set<T>().Find(key);
            if (existing != null)
            {
                _entities.Entry(existing).CurrentValues.SetValues(entity);
            }
            return await Save();
        }
    }
}
