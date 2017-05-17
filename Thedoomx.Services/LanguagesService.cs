using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thedoomx.Data.Models;
using Thedoomx.Data.Repositories;
using Thedoomx.Services.Contracts;

namespace Thedoomx.Services
{
    public class LanguagesService : ILanguagesService
    {
        private readonly IDbRepository<Language, int> languages;

        public LanguagesService(IDbRepository<Language, int> languages)
        {
            this.languages = languages;
        }

        public IQueryable<Language> GetAll()
        {
            return this.languages.All();
        }

        public void Add(Language model)
        {
            this.languages.Add(model);
            this.languages.Save();
        }

        public void Delete(Language model)
        {
            this.languages.Delete(model);
            this.languages.Save();
        }
    }
}
