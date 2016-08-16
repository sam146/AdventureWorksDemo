﻿namespace AW.WebAPI
{
    using App_Start;
    using System.Web.Http;
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(DependencyInjectionConfig.Register);
        }
    }
}
