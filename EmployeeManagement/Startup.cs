using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EmployeeManagement
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<AppDbContext>(
                options => options.UseSqlServer("Server=localhost,1433\\ Database=EmployeeDB; User=SA; Password=MyPassword123;")
            );

            services.AddMvc().AddXmlSerializerFormatters();
            services.AddScoped <IEmployeeRepository, SQLEmployeeRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Serves default / index file 
            //app.UseDefaultFiles();

            //To use another file as default
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("foo.html");
            //app.UseDefaultFiles(defaultFilesOptions);

            app.UseStaticFiles();
            //app.UseMvc();

            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World");               
            //});

            //// 1st middleware
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1: Request");
            //    await next();
            //    logger.LogInformation("MW1: Response");
            //});

            //// 2nd middleware
            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2: Request");
            //    await next();
            //    logger.LogInformation("MW2: Response");
            //});

            ////3rdmiddleware
            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //    await context.Response.WriteAsync("MW3: Request and response handled" );
            //    logger.LogInformation("MW3: Response");
            //});
        }
    }
}
