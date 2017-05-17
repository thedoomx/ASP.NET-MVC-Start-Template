namespace Thedoomx.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Models;
    using Thedoomx.Services.Contracts;
    using Thedoomx.Web.Controllers.Common;
    using Thedoomx.Web.ViewModels.Language;
    public class LanguagesController : BaseController
    {
        private readonly ILanguagesService languages;
        private readonly IUsersService users;

        public LanguagesController(ILanguagesService languages, IUsersService users)
        {
            this.languages = languages;
            this.users = users;
        }

        public ActionResult Index()
        {
            return View(this.languages.GetAll().Where(x => x.DeletedOn.HasValue == false));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(Language model)
        {
            this.languages.Add(model);

            return this.RedirectToAction(nameof(this.Index));
        }


        public ActionResult Index2()
        {
            return this.View(this.users.GetAll().Where(x => x.DeletedOn.HasValue == false));
        }

        [HttpGet]
        public ActionResult Create2()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create2(UserViewModel model)
        {
            var user = this.Mapper.Map<User>(model);
            user.CreatedOn = DateTime.UtcNow;
            user.UserName = model.Email;

            this.users.CreateUser(user, model.Password);

            return this.RedirectToAction(nameof(this.Index));
        }

        public ActionResult Delete(int id)
        {
            var lang = this.languages.GetAll().FirstOrDefault(x => x.Id == id);

            this.languages.Delete(lang);

            return this.RedirectToAction(nameof(this.Index));
        }

        public ActionResult Delete2(string id)
        {
            var user = this.users.GetAll().FirstOrDefault(x => x.Id == id);

            this.users.Delete(user);

            return this.RedirectToAction(nameof(this.Index2));
        }
    }
}