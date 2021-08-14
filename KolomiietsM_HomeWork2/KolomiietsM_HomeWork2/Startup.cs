using KolomiietsM_HomeWork2.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KolomiietsM_HomeWork2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IServiceCollection services;
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            this.services = services;

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KolomiietsM_HomeWork2", Version = "v1" });
            });

            services.AddSingleton<MainLogicService>();
            services.AddTransient<CheckService>();
            services.AddTransient<IContentService, ContentService>();
            services.AddTransient<ISaveService, SaveService>();
            services.AddTransient<PublicService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KolomiietsM_HomeWork2 v1"));
            }

            app.UseCustomMiddleware(); //THIS IS MY EXTENSION METHOD for adding custom middleware

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
