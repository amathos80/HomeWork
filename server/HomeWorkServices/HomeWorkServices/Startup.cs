using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HomeWorkServices.Repositories;
using HomeWorkServices.Services.Interfaces;
using HomeWorkServices.Services;

namespace HomeWorkServices
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


            services.AddDbContext<HomeWorkContext>(options =>
            {
                
                //options.UseLazyLoadingProxies();
                options.UseSqlite(
                 Configuration.GetConnectionString("DefaultConnection"));
            });

            var config = new MapperConfiguration(cfg => { cfg.AddProfile<Mapping.MappingProfile>(); });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddScoped<DbContext, HomeWorkContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProjectRepository,ProjectRepository>();
            services.AddTransient<IProjectService, ProjectService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
