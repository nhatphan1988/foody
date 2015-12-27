using Autofac;
using Autofac.Integration.Mvc;
using FoodyDomain.Model;
using FoodyRespository.Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Foody.App_Start
{
    public interface A
    {
        void Create();
    }
    public interface B
    {
        void Create(IContainer container);
    }
    public class B1 : B
    {
        IContainer _container;
        A a;
        public void Create(IContainer container)
        {
            _container = container;
            a = container.Resolve<A>();
            a.Create();
        }


    }

    public class A1: A
    {
        public void Create()
        { }


    }
    public class AutofacConfig
    {
        

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MenuResponsitory>().As<FoodyDomain.IResponsitory<MenuEntity>>().InstancePerRequest();
            builder.RegisterType<B1>().As<B>();
            builder.RegisterType<A1>().As<A>();
            var container = builder.Build();
            B b = container.Resolve<B>();
            b.Create(container);
            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}