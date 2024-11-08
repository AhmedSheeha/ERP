using System.Linq.Expressions;

namespace ERP.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        public T FindById(int id);
        public Task<T> FindByIdAsync(int id);
        public IEnumerable<T> FindAll();
        public Task<IEnumerable<T>> FindAllAsync();
        Task<T> SelectOneAsync(Expression<Func<T, bool>> match);
        T SelectOne(Expression<Func<T, bool>> match);
        public Task<IEnumerable<T>> FindAllAsync(params string[] eagers);
        void AddOne(T MyItem);
        void UpdateOne(T MyItem);
        void DeleteOne(T MyItem);
        void AddList(IEnumerable<T> Items);
        void UpdateList(IEnumerable<T> Items);
        void DeleteList(IEnumerable<T> Items);


    }
}
