using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Data.Models
{
    public class Session
    {
        private readonly AppDBContent _appDBContent;
        public Session(AppDBContent appDBContent)
        {
            _appDBContent = appDBContent;
        }
        public string sessionID { get; set; }
        public Login login { get; set; }

        //создание или получение текущей сессии пользователя
        public static Session GetSession(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string sessionID = session.GetString("sessionID") ?? Guid.NewGuid().ToString();

            session.SetString("sessionID", sessionID);

            return new Session(context) { sessionID = sessionID };
        }

        //добавление в сессию логина
        public void AddLogin(User user)
        {
            _appDBContent.login.Add(new Login
            {
                sessionID = this.sessionID,
                time = DateTime.Now,
                user = user
            });
            _appDBContent.SaveChanges();
        }

        //получение логина
        public Login GetLogin() => _appDBContent.login.Include(l => l.user).FirstOrDefault(l => l.sessionID == this.sessionID);

        public bool ChkSession()
        {
            var obj = _appDBContent.login.Include(l => l.user).FirstOrDefault(l => l.sessionID == this.sessionID); ;
            if (obj == null || obj.time < DateTime.Now.AddDays(-1))
            {
                return false;
            }
            return true;
        }

    }
}
