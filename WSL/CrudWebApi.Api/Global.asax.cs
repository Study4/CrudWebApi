using CrudWebApi.Api.App_Start;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Routing;

namespace Crud_WebApi.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Configure();

            GlobalConfiguration.Configure(WebApiConfig.Register);

            //使用JS駝峰式命名
            var jsonformatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            jsonformatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            ////將 Emun 轉換成 String
            //JsonConvert.DefaultSettings = (() =>
            //{
            //    var settings = new JsonSerializerSettings();
            //    settings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
            //    return settings;
            //});
        }
    }
}
