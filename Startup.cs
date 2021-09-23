using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksWebApi.Contexts;
using BooksWebApi.Mappers;
using BooksWebApi.Repositories;
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

namespace BooksWebApi
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
            //dependency injections
            services.AddDbContext<BooksApiDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("BooksDbConnection")));
            services.AddScoped<IBookRepo, SqlBooksRepo>();
            //services.AddScoped<IBookService, BookService>(); // no need but I like the idea of separating business logic and data access logic

            //Mapping model to dto
            services.AddAutoMapper(typeof(BookMapper));
            
            services.AddControllers();
           
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
