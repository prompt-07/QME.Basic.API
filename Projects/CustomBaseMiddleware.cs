﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QME.Basic.API.Projects
{
    public static class CustomBaseMiddleware
    {
        
            public static void AddHttpContextAccessor(this IServiceCollection services)
            {
                services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            }

            public static IApplicationBuilder UseHttpContext(this IApplicationBuilder app)
            {
                MyHttpContext.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());
                return app;
            }
        
        public class MyHttpContext
        {
            private static IHttpContextAccessor m_httpContextAccessor;

            public static HttpContext Current => m_httpContextAccessor.HttpContext;

            public static string AppBaseUrl => $"{Current.Request.Scheme}://{Current.Request.Host}{Current.Request.PathBase}";

            internal static void Configure(IHttpContextAccessor contextAccessor)
            {
                m_httpContextAccessor = contextAccessor;
            }
        }

        


    }
}
