using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using metanitLessions.Services;
using Microsoft.AspNetCore.Http;

namespace metanitLessions
{
    public class MessageMiddleware
    {
        private readonly RequestDelegate _next;

        public MessageMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMessageSender messageSender)
        {
            await context.Response.WriteAsync(messageSender.Send());
        }
    }
}
