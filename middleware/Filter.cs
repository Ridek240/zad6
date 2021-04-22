using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrowserNET;
using Microsoft.AspNetCore.Http;

namespace zad6.middleware
{
    public class Filter
    {
        private RequestDelegate _next;
        public Filter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var parser = new UserAgentParser(context.Request.Headers["User-Agent"]);
            parser.Determine();

            var browserName = parser.BrowserName;
            var forbittenBrowsers = new List<string> { "Edge", "Internet Explorer", "EdgeChromium" };

            if (forbittenBrowsers.Any(browserName.Contains))
                await context.Response.WriteAsync("Nielegalnia przeglądarka");
            else
                await _next(context);
        }
    }
}
