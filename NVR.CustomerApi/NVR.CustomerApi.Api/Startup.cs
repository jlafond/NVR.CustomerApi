using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NVR.CustomerApi.DataLayer.Interfaces;
using NVR.CustomerApi.DataLayer.Repositories;
using NVR.CustomerApi.Services.Interfaces;
using NVR.CustomerApi.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace NVR.CustomerApi.Api
{
    public class Startup
    {

        private const string _apiVersion = "V1";
        private const string _serviceName = "NVR Customer API";

        public Startup(IHostingEnvironment env)
        {
            Environment = env;
        }

        public IHostingEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMvcCore();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin());
            });

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            
            if (Environment.IsDevelopment())
            {
                services.AddSwaggerGen(c =>
                    c.SwaggerDoc(_apiVersion.ToLower(), new Microsoft.OpenApi.Models.OpenApiInfo { Title = _serviceName, Version = _apiVersion })
                ); ;
            }
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NVR Customer API");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
