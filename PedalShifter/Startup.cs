using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PedalShifter.Data;
using PedalShifter.Data.Data;
using PedalShifter.Data.Interfaces;
using PedalShifter.Domain.Interfaces;
using PedalShifter.Domain.Models;
using System;
using System.Threading.Tasks;

namespace PedalShifter
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
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBikeRepository, BikeRepository>();
            services.AddTransient<IHostRepository, HostRepository>();
            services.AddTransient<IRenterRepository, RenterRepository>();
            services.AddTransient<IHostOpenHourRepository, HostOpenHourRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IBikeService, BikeService>();
            services.AddTransient<IHostService, HostService>();
            services.AddTransient<IRenterService, RenterService>();
            services.AddTransient<IHostOpenHourService, HostOpenHourService>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/account/login";
                options.LogoutPath = $"/account/logout";
                options.AccessDeniedPath = $"/account/accessDenied";
            });

            services.AddAuthorization(options => {
                options.AddPolicy("Host",
                    builder => builder.RequireRole("Host"));
                options.AddPolicy("Renter",
                    builder => builder.RequireRole("Renter"));
                options.AddPolicy("HostRenter",
                    builder => builder.RequireRole("Host", "Renter"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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
