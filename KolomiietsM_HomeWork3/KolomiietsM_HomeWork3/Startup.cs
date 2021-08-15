using KolomiietsM_HomeWork3.Projections;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KolomiietsM_HomeWork3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            NewConfiguration = new ConfigurationBuilder().AddJsonFile("customConfigs.json").AddConfiguration(configuration).Build();
        }

        public IConfiguration Configuration { get; }
        public IConfiguration NewConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KolomiietsM_HomeWork3", Version = "v1" });
            });

            services.Configure<Server>(NewConfiguration);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<Server> options)
        {
            Server gotServer = NewConfiguration.GetSection("server").Get<Server>();
            var bindServer = new Server(); //as alternative
            NewConfiguration.Bind(bindServer);

            DateTime createdDate;
            DateTime.TryParse(NewConfiguration["created"], out createdDate);


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KolomiietsM_HomeWork3 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Server {gotServer.name} - {NewConfiguration["addres"]}:{gotServer.port}.\n" +
                        $"Located on: {NewConfiguration["location"]}// created {createdDate}.\n" +
                        $"info [{gotServer.delay} delay; {gotServer.settings.connections} max connections]");
                });
            });
        }
    }
}
