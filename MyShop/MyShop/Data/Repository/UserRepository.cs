using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Repository
{
    public class UserRepository : IUser
    {
        private readonly AppDBContent _appDBContent;
        public UserRepository(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public User GetUser(string name) => _appDBContent.user.FirstOrDefault(p => p.name == name);
    }
}
