using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Thedoomx.Data.Models;
using Thedoomx.Data.Repositories;
using Thedoomx.Services.Contracts;

namespace Thedoomx.Services
{
    public class UsersService : IUsersService
    {
        private readonly IDbRepository<User, string> users;
        private readonly UserManager<User> userManager;

        public UsersService(IDbRepository<User, string> users, UserManager<User> userManager)
        {
            this.users = users;
            this.userManager = userManager;
        }

        public IQueryable<User> GetAll()
        {
            return this.users.All();
        }

        public void CreateUser(User user, string password)
        {
            user.UserName = user.Email;
            this.userManager.Create(user, password);
            this.users.Save();
        }

        public void Delete(User user)
        {
            this.users.Delete(user);
            this.users.Save();
        }
    }
}
