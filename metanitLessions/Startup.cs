using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace metanitLessions
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = "Production";
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStatusCodePages("text/plain", "Error. Status Code : {0}");

            app.UseStatusCodePagesWithReExecute("/error", "?code={0}");

            app.UseRouting();

            app.Map("/error", ap => ap.Run(async (context) =>

            {

                await context.Response.WriteAsync($"Err: {context.Request.Query["code"]}");
                //await context.Response.WriteAsync("DivideByZeroException occured!");
            }));

            app.Map("/hello", ap => ap.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello ASP.NET Core");
            }));


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/main", async context =>
                {
                    int x = 0;
                    int y = 8 / x;
                    await context.Response.WriteAsync($"result = {y}");
                });
            });
        }
    }
}
