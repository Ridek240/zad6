using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace zad6.middleware
{
    public static class Filtere
    {
        public static IApplicationBuilder UseFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Filter>();
        }
    }
}
