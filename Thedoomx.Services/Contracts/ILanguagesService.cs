namespace Thedoomx.Services.Contracts
{
    using System.Linq;
    using Thedoomx.Data.Models;

    public interface ILanguagesService
    {
        IQueryable<Language> GetAll();

        void Add(Language model);

        void Delete(Language model);
    }
}
