using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App1.Context;
using App1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App1
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
            services.AddControllersWithViews();

            //sadece bir tane service objesi.
            services.AddSingleton<BookContext>();
            services.AddSingleton<UserContext>();

            //her connectte service objesi.
            services.AddScoped<MessageService>();
            services.AddScoped<ScopedService>();

            //her requestte service objesi.
            services.AddTransient<BookService>();
            services.AddTransient<UserService>();
            services.AddTransient<TransientService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    //uygulamamýzýn default hangi controller ve hangi actiondan açýlacaðý burada belirleniyor
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
