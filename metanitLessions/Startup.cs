using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private IServiceCollection _services;
        public void ConfigureServices(IServiceCollection services)
        {
            _services = services;
            var servs = services.ToList();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.Run(async context =>
            {
                var sb = new StringBuilder();
                sb.Append("<h1>��� �������<h1>");
                sb.Append("<table>");
                sb.Append("<tr><th>���</th><th>LifeTime</th><th>����������</th></tr>");
                foreach (var svc in _services)
                {
                    sb.Append("<tr>");
                    sb.Append($"<td>{svc.ServiceType.FullName}</td>");
                    sb.Append($"<td>{svc.Lifetime}</td>");
                    sb.Append($"<td>{svc.ImplementationType?.FullName}</td>");
                    sb.Append("</tr>");

                }
                sb.Append("</table>");
                context.Response.ContentType = "text/html;charset=utf8";
                await context.Response.WriteAsync(sb.ToString());
            });
        }
    }
}
