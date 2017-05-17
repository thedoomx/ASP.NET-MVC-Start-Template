namespace Thedoomx.Data.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    public interface IDbRepository<T, in TKey> 
        where T : class
    {
        Task<IEnumerable<T>> AllAsync();

        IQueryable<T> All();

        T GetById(TKey id);

        void Add(T entity);

        void Delete(T entity);

        void Save();

        void HardDelete(T entity);
    }
}
