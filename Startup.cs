using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using aariveros_reporting_api.Models;
using System;
using Newtonsoft.Json;

namespace aariveros_reporting_api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var server = Environment.GetEnvironmentVariable("MSSQL_DB_HOST");
            var port = Environment.GetEnvironmentVariable("MSSQL_DB_PORT");
            var db = Environment.GetEnvironmentVariable("MSSQL_DB_DATABASE");
            var user = Environment.GetEnvironmentVariable("MSSQL_DB_USER");
            var password = Environment.GetEnvironmentVariable("MSSQL_DB_PASSWORD");

            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", corsBuilder.Build());
            });

            services.AddDbContext<ReportingContext>(options =>
                options.UseSqlServer(
                    "Server=" + server +  "," + port + 
                    ";Database=" + db + 
                    ";User=" + user + 
                    ";Password=" + password));

             services.AddMvc()
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                });

            services.AddSingleton<IEnterprisesRepository, EnterprisesRepository>();
            services.AddSingleton<IProjectsRepository, ProjectsRepository>();
            services.AddSingleton<IEmployeesRepository, EmployeesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            app.UseCors("AllowAll");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvcWithDefaultRoute();

            
        }
    }
}
