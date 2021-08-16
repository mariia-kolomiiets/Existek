using KolomiietsM_HomeWork4.OwnLogger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork4
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KolomiietsM_HomeWork4", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> startupLogger, ILoggerFactory loggerFactory) //
        {
            string path = $"{Directory.GetCurrentDirectory()}/custom.logs";

            //loggerFactory.AddCustomProvider(path); //ALTERNATIVE #1 WITH DI ILoggerFactory
            //ILogger customLogger = loggerFactory.CreateLogger("CustomLogger");

            //var ownLoggerFactory = LoggerFactory.Create(builder => //ALTERNATIVE #2
            // {
            //     builder.AddProvider(new CustomLoggerProvider(path));
            // });

            startupLogger.Log(LogLevel.Warning, "First logger Warning Warning Warning");
            startupLogger.Log(LogLevel.Information, "Second logger Information");
            startupLogger.Log(LogLevel.Trace, "Third logger Trace Trace");
            startupLogger.Log(LogLevel.Debug, "Fourth logger Debug");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KolomiietsM_HomeWork4 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/log", async requestDelegate =>
                {
                    startupLogger.Log(LogLevel.Critical, "Fifth logger Critical! Critical! Critical!");
                    startupLogger.Log(LogLevel.Error, "Sixth logger ErrorErrorErrorErrorErrorError");
                    await requestDelegate.Response.WriteAsync("Logged!");
                });
                endpoints.MapControllers();
            });
        }
    }
}
