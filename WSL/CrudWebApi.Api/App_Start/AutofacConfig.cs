using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CrudWebApi.Api.Modules;
using CrudWebApi.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace CrudWebApi.Api.App_Start
{
    public class AutofacConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration. for IIS
            // Note OWIN 會不同
            var config = GlobalConfiguration.Configuration;

            // For self hosting
            //var config = new HttpSelfHostConfiguration("http://localhost:8080");

            // For Owin
            //var config = new HttpConfiguration();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());



            #region registe AutoMapper

            builder.RegisterAssemblyTypes().AssignableTo(typeof(Profile)).As<Profile>();
            builder.RegisterModule(new AutoMapperModule());
            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            #endregion



            #region Regist Service
            builder.RegisterType<EmployeeService>().As<IEmployeeService>().InstancePerRequest();

            //var services = Assembly.Load("Study4.Services");
            //builder.RegisterAssemblyTypes(services).AsImplementedInterfaces();
            #endregion


            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
