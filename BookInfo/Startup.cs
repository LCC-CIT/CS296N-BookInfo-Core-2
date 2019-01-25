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

            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();     // This has to come before UseMvc...
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

        }
    }
}
