using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.EntityFrameWorkCore;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Service;

namespace UserManagementOnionPattern
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
            services.AddControllers();


            //  string mySqlConnectionStr = Configuration.GetConnectionString("MyConnectionString");

            //  services.AddDbContextPool<ApplicationDbContext>(t => t.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), v => v.MigrationsAssembly("UserManagment.Api")));

            services.AddDbContextPool<ApplicationDbContext>(t => t.UseMySql(Configuration.GetConnectionString("MyConnectionString") , v => v.MigrationsAssembly("UserManagementOnionPattern")));

            services.AddTransient<IUserRepository, UserRepository>();  //percall

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddTransient<IUserProfileRepository, UserProfileRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
