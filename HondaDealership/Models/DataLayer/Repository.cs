using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HondaDealership.Models.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApplicationDbContext Context { get; set; }
        protected DbSet<T> DbSet { get; set; }

        public Repository(ApplicationDbContext ctx)
        {
            Context = ctx;
            DbSet = Context.Set<T>();
        }

        public virtual IQueryable<T> GetAll(QueryOptions<T> options = null)
        {
            IQueryable<T> query = DbSet;

            if (options != null)
            {
                if (options.OrderBy != null)
                {
                    query = options.OrderByDescending ?
                        query.OrderByDescending(options.OrderBy) :
                        query.OrderBy(options.OrderBy);
                }
            }

            return query;
        }

        public virtual T Find(int id)
        {
            return DbSet.Find(id);
        }
        public virtual void Insert(T entity) => DbSet.Add(entity);
        public virtual void Update(T entity) => DbSet.Update(entity);
        public virtual void Delete(T entity) => DbSet.Remove(entity);
        public virtual void Save() => Context.SaveChanges();
    }
}
