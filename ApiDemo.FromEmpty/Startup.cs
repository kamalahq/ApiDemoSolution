using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ApiDemo.FromEmpty
{
    public class Startup
    {
         public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(cfg =>
            {
                cfg.AddPolicy("allowAny", p =>
                {
                    p.AllowAnyHeader();
                    p.AllowAnyMethod();
                    p.AllowAnyOrigin();
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("allowAny");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
