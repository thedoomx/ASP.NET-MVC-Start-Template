namespace Thedoomx.Services.Contracts
{
    using System.Linq;
    using Thedoomx.Data.Models;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        void CreateUser(User user, string password);

        void Delete(User user);
    }
}
