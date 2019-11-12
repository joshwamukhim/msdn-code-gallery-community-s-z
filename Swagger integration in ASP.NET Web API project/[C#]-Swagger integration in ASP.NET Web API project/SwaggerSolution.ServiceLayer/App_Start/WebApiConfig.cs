﻿using System;
using System.Web.Http;
using SwaggerSolution.ServiceLayer.Handlers;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace SwaggerSolution.ServiceLayer
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute
            (
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.MessageHandlers.Add(new CorsHandler());
            config.MapHttpAttributeRoutes();
            config.EnsureInitialized();
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }

        public class FirstCharLowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return Char.ToLowerInvariant(propertyName[0]) + propertyName.Substring(1);
            }
        }
    }
}