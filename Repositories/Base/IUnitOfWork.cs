using ERP.Models;

namespace ERP.Repositories.Base
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Category> Categories { get; }
        IRepository<Item> Items { get; }
        IEmpRepo Employees { get; }

        int CommitChanges();
    }
}
