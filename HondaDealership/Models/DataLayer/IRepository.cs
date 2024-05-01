using System.Linq.Expressions;

namespace HondaDealership.Models.DataLayer
{
    public interface IRepository<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
        IQueryable<T> GetAll(QueryOptions<T> options = null);

    }
}
