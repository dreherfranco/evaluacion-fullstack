using backend.DbConfiguration;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace backend.Repository
{
    public class Repository<T> where T: class
    {
        private AppDbContext Context { get; set; }
        public Repository(AppDbContext context)
        {
            Context = context;
        }

        public async Task<T> Add(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null)
        {
            if (filter == null)
            {
                return await this.Context.Set<T>().ToListAsync();
            }
            else
            {
                return await this.Context.Set<T>().Where(filter).ToListAsync();

            }

        }

        public async Task Delete(T entity)
        {
            this.Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entidad)
        {
            this.Context.Entry(entidad).State = EntityState.Modified;
            await this.Context.SaveChangesAsync();
        }

    }
}
