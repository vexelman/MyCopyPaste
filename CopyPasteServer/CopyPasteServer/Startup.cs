using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CopyPasteDAL;
using CopyPasteDAL.Models;
using Microsoft.EntityFrameworkCore;
using CopyPasteBLL;



namespace CopyPasteServer
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
            services.AddCors(p => p.AddPolicy("AllowAll", option =>
            {
                option.AllowAnyMethod();
                option.AllowAnyHeader();
                option.AllowAnyOrigin();
            }));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CopyPasteServer", Version = "v1" });
            });
            services.AddScoped(typeof(IActionsBLL), typeof(ActionsBLL));
            services.AddScoped(typeof(IActionsDal), typeof(ActionsDal));
          


            services.AddDbContext<CopyPasteDataContext>(option =>
            option.UseSqlServer("Server=P39\\SQL;Database=CopyPasteData;Trusted_Connection=true"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CopyPasteServer v1"));
            }
            app.UseCors("AllowAll");

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
