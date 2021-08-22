using KolomiietsM_HomeWork5.Models;
using KolomiietsM_HomeWork5.Constraints;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KolomiietsM_HomeWork5
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
            services.AddSingleton<Model>();


            services.Configure<RouteOptions>(options =>
            {
                options.ConstraintMap.Add("ownPut", typeof(OwnPutConstraint));
                options.ConstraintMap.Add("ownDelete", typeof(OwnDeleteConstraint));
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KolomiietsM_HomeWork5", Version = "v1" });
            });

            
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KolomiietsM_HomeWork5 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "post3params",
                    pattern: "{controller=Home}/{action=PostPhone}/{phone:regex(^\\(?([0-9]{{3}})\\)?[-.]?([0-9]{{3}})[-.]?([0-9]{{4}})$)}=-={card:int}=-={sum:double}"); //AS ALTERNATIVE TO ATTRIBUTE ROUTING

                endpoints.MapControllerRoute(
                    name: "post2params",
                    pattern: "{controller=Home}/{action=Post}/{email:regex(\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)}=-={card:int}"); //AS ALTERNATIVE TO ATTRIBUTE ROUTING

                endpoints.MapControllerRoute(
                    name: "put",
                    pattern: "{controller=Home}/{action=Put}/{id:ownPut}/{user:alpha}/{email:regex(\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)}/{phone:regex(^\\(?([0-9]{{3}})\\)?[-.]?([0-9]{{3}})[-.]?([0-9]{{4}})$)}/{card:int}"); //AS ALTERNATIVE TO ATTRIBUTE ROUTING

                endpoints.MapControllers();

            });
        }
    }
}
