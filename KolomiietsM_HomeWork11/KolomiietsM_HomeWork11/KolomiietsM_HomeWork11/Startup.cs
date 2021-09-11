using KolomiietsM_HomeWork11.Context;
using KolomiietsM_HomeWork11.OwnRequirement;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace KolomiietsM_HomeWork11
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
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<UsersContext>(options => options.UseSqlServer(connection));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
                });

            services.AddTransient<IAuthorizationHandler, OwnEditHandler>();

            ///////////////////////////////////////////////
            ///////////////////////////////////////////////
            ///////////////////////////////////////////////
            services.AddAuthorization(opts => {
                opts.AddPolicy("ACCESS", policy => {
                    policy.RequireClaim("reading", "readEditText");
                    policy.RequireAssertion(context => 
                        {
                            return context.User.IsInRole("admin");
                        });
                    policy.AddRequirements(new OwnEditRequirement("readEditText"));
                });
            });
            ///////////////////////////////////////////////
            ///////////////////////////////////////////////
            ///////////////////////////////////////////////

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "KolomiietsM_HomeWork11", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "KolomiietsM_HomeWork11 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
