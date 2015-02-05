﻿using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebAPI;

[assembly: OwinStartup(typeof(Startup))]
namespace WebAPI
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}