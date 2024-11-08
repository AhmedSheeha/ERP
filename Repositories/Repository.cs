using ERP.Data;
using ERP.Repositories.Base;
using ERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ERP.Repositories
{
    
    public class Repository<T> : IRepository<T> where T : class
    {
        
        private readonly AppDbContext _context;
        public T FindById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public IEnumerable<T> FindAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return _context.Set<T>().SingleOrDefault(match);
        }
        public IEnumerable<T> FindAll(params string[] eagers)
        {
            IQueryable<T> query = _context.Set<T>();
            if(eagers.Length > 0)
            {
                foreach(string eager in eagers)
                {
                     query = query.Include(eager);
                }
            }
            return query.ToList();
        }
        public async Task<IEnumerable<T>> FindAllAsync(params string[] eagers)
        {
            IQueryable<T> query = _context.Set<T>();
            if (eagers.Length > 0)
            {
                foreach (string eager in eagers)
                {
                    query = query.Include(eager);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> SelectOneAsync(Expression<Func<T, bool>> match)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(match);
        }

        public void AddOne(T MyItem)
        {
            _context.Set<T>().Add(MyItem);
            _context.SaveChanges();
        }

        public void UpdateOne(T MyItem)
        {
            _context.Set<T>().Update(MyItem);
            _context.SaveChanges();
        }

        public void DeleteOne(T MyItem)
        {
            _context.Set<T>().Remove(MyItem);
            _context.SaveChanges();
        }

        public void AddList(IEnumerable<T> Items)
        {
            _context.Set<T>().AddRange(Items);
            _context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> Items)
        {
            _context.Set<T>().UpdateRange(Items);
            _context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> Items)
        {
            _context.Set<T>().RemoveRange(Items);
            _context.SaveChanges();
        }

        public Repository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        } 
    }
}
