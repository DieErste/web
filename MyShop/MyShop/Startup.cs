using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyShop.Data;
using MyShop.Data.Interfaces;
using MyShop.Data.Models;
using MyShop.Data.Repository;

namespace MyShop
{
    public class Startup
    {
        private readonly ILogger _logger;
        private IConfigurationRoot _confString;
        public Startup(ILogger<Startup> logger, IHostingEnvironment hostEnv)
        {
            _logger = logger;
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // регистрация модулей/плагинов
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("########################## ConfigureServices");
            try
            {
                services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
                _logger.LogInformation("########################## db OK");
            }
            catch (SqlException)
            {
                _logger.LogInformation("########################## db ne OK");
            }
            //связка методов описания и реализации
            //services.AddTransient<ICategory,MockCategory>();
            //services.AddTransient<IItem, MockItem>();
            services.AddTransient<ICategory,CategoryRepository>();
            services.AddTransient<IItem, ItemRepository>();
            services.AddTransient<IOrder, OrderRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IImg, ImgRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//сессия
            services.AddScoped(sp => ShopCart.GetCart(sp));//старт новой сессии корзины пользователя
            services.AddScoped(sp => Session.GetSession(sp));//старт новой сессии учетки пользователя
            services.AddMvc(); //модель-вид-контроллер(добавляется через nuget)
            services.AddMemoryCache();//кэш
            services.AddSession();//сессия
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _logger.LogInformation("########################## Configure");
            app.UseDeveloperExceptionPage(); //отображение страницы с ошибками
            app.UseStatusCodePages(); //отображение кода страниц
            app.UseStaticFiles(); //отображение статических файлов(css, img...)(добавляется через nuget)
            app.UseSession();
            //app.UseMvcWithDefaultRoute(); //если не указываем путь страницы будет использоваться url по умолчанию
            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");///{id?}");
                routes.MapRoute(name: "items", template: "Items/{action?}/{categoryName?}", defaults: new { Controller = "Items", action = "List" });
                routes.MapRoute(name: "auth", template: "Auth/{action?}", defaults: new { Controller = "Auth", action = "Login" });
                routes.MapRoute(name: "controlPanel", template: "ControlPanel/{action?}", defaults: new { Controller = "ControlPanel", action = "Menu" });
                routes.MapRoute(name: "categoryManage", template: "CategoryManage/{action?}/{id?}", defaults: new { Controller = "CategoryManage", action = "List" });
                routes.MapRoute(name: "itemManage", template: "ItemManage/{action?}/{categoryName?}", defaults: new { Controller = "ItemManage", action = "List" });
                routes.MapRoute(name: "shopCart", template: "ShopCart/{action?}", defaults: new { Controller = "ShopCart", action = "Index" });
                routes.MapRoute(name: "order", template: "Order/{action?}", defaults: new { Controller = "Order", action = "Checkout" });
                routes.MapRoute(name: "imgManage", template: "ImgManage/{action?}", defaults: new { Controller = "ImgManage", action = "List" });
            });

            //заполнение бд первоначальное
            using(var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent appDBContent = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(appDBContent);
            }
        }
    }
}
