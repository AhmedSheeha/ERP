using ERP.Data;
using ERP.Models;
using ERP.Repositories.Base;

namespace ERP.Repositories
{
    public class UniteOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UniteOfWork(AppDbContext context)
        {
            _context = context;
            Categories = new Repository<Category>(_context);
            Items = new Repository<Item>(_context);
            Employees = new EmpRepo(_context);
        }
        public IRepository<Category> Categories { get; private set; }

        public IRepository<Item> Items { get; private set; }

        public IEmpRepo Employees { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
