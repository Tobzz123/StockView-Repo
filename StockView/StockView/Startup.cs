using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StockView.Data;
using StockView.Models;
using StockView.Models.Forum;

namespace StockView
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(
              Configuration.GetConnectionString("StockView")));
            services.AddDefaultIdentity<GenericUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
               /*.AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<stockviewContext>();*/


            /* services.AddDbContext<IdentityDataContext>(options =>
              options.UseSqlServer(
             Configuration.GetConnectionString("IdentityDataContext")));*/




            // services.AddIdentity<GenericUser, IdentityRole>().AddEntityFrameworkStores<stockviewContext>();

            //Configure Identity
            services.Configure<IdentityOptions>(options =>
             {
                 options.Password.RequiredLength = 8;
                 options.User.RequireUniqueEmail = true; 
             });

            //services.AddTransient<IEmailSender, EmailSender>();
            //services.AddScoped<IForum, ForumService>();

            

            services.AddMvc();
            services.AddControllersWithViews();
            services.AddRazorPages();
           /* services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<IdentityDataContext>;*/
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminRole", policy => policy.RequireRole("Admin"));
                options.AddPolicy("ManagerRole", policy => policy.RequireRole("Manager"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

           
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


           /* app.UseMvc(routes =>
            {
                routes.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
            });*/


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
