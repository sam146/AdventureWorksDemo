﻿namespace AW.WebAPI
{
    using Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            WebApiRegister(config);
            OdataRegister(config);
        }

        private static void WebApiRegister(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ApplicationExceptionFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        private static void OdataRegister(HttpConfiguration config)
        {
            var builder = new ODataConventionModelBuilder();
            builder.EntitySet<Models.Employee>("Employees");
            builder.EntitySet<Models.EmployeeDepartmentHistory>("EmployeeDepartmentHistories");
            builder.EntitySet<Models.Shift>("Shifts");
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: "odata",
                model: builder.GetEdmModel());

            // create the formatters with the custom serializer provider and use them in the configuration.
            //var odataFormatters = ODataMediaTypeFormatters.Create(new AppODataSerializerProvider(), new DefaultODataDeserializerProvider());
            //config.Formatters.InsertRange(0, odataFormatters);
        }
    }
}
