using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ShopApp.Api.AccessLayer;
using ShopApp.Api.AccessLayer.Profiles;
using ShopApp.Api.AccessLayer.Repositories.Abstracts;
using ShopApp.Api.AccessLayer.Repositories.Concretes;
using ShopApp.Api.BusinessLayer.ManagerServices.Abstracts;
using ShopApp.Api.BusinessLayer.ManagerServices.Concretes;
using ShopApp.Api.EntityLayer.Models;

namespace ShopApp.Api
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
            
     

            services.AddDbContext<ShopAppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("MyConnection")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ShopApp.Api", Version = "v1" });
            });



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CategoryProfile());
                mc.AddProfile(new ProductProfile());

            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryManager, CategoryMananger>();
            services.AddScoped<IProductManager, ProductManager>();

            services.AddSingleton(mapper);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (IServiceScope scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetService<ShopAppDbContext>().Database.Migrate();
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ShopApp.Api v1"));
            }

            //db.Database.EnsureCreated();
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
