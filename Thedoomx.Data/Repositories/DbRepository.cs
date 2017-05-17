namespace Thedoomx.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;
    using Models.Common;
    public class DbRepository<T, TKey> : IDbRepository<T, TKey>
        where T : class, IDeletableEntity, IAuditInfo
    {
        private IDbSet<T> DbSet { get; }

        private DbContext Context { get; }

        public DbRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        public async Task<IEnumerable<T>> AllAsync()
        {
            return await this.DbSet.ToListAsync();
        }

        public IQueryable<T> All()
        {
            return this.DbSet;
        }

        public void Add(T entity)
        {
            this.DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            entity.IsDeleted = true;
            entity.DeletedOn = DateTime.UtcNow;
        }

        public T GetById(TKey id)
        {
            return this.DbSet.Find(id);
        }

        public void HardDelete(T entity)
        {
            this.DbSet.Remove(entity);
        }

        public void Save()
        {
            this.Context.SaveChanges();
        }
    }
}
