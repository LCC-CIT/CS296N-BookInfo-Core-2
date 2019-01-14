using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using BookInfo.Repositories;
using BookInfo.Models;
using Microsoft.AspNetCore.Identity;

namespace BookInfo
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
            => Configuration = configuration;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(
                        Configuration["Data:BookInfo:ConnectionString"]));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(
                   options => options.UseSqlite(
                       Configuration["Data:BookInfo:SQLiteConnectionString"]));
            }

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();

            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            /*    // Optional
            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = System.TimeSpan.FromMinutes(30);
                options.LoginPath = "/Account/Login"; // If the LoginPath is not set here, ASP.NET Core will default to /Account/Login
                options.LogoutPath = "/Account/Logout"; // If the LogoutPath is not set here, ASP.NET Core will default to /Account/Logout
                options.AccessDeniedPath = "/Account/AccessDenied"; // If the AccessDeniedPath is not set here, ASP.NET Core will default to /Account/AccessDenied
                options.SlidingExpiration = true;
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
<<<<<<< HEAD
            app.UseAuthentication();   // Must precede app.UseMvc!!!
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
            ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
=======
            app.UseAuthentication();     // This has to come before UseMvc...
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

>>>>>>> AddLogin
        }
    }
}
