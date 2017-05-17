using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Thedoomx.Data.Models;
using Thedoomx.Web.Infrastructure.AutoMapper;

namespace Thedoomx.Web.ViewModels.Language
{
    public class UserViewModel : IMapTo<User>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}