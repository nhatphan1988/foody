using Autofac;
using Autofac.Integration.Mvc;
using FoodyDomain.Model;
using FoodyRespository.Respository;
using System.Web;
using System.Web.Mvc;

namespace Foody.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MenuResponsitory>().As<FoodyDomain.IResponsitory<MenuEntity>>().InstancePerRequest();
            builder.Register(c => new HttpContextWrapper(HttpContext.Current))
                            .As<HttpContextBase>()
                            .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerRequest();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerRequest();
            //builder.RegisterType<LoggingCardService>().InstancePerRequest();
            //builder.RegisterType<CardService>().InstancePerRequest();
            //builder.Register(c =>
            //{
            //    ICardService cardService = c.Resolve<CardService>();
            //    cardService = c.Resolve<LoggingCardService>(TypedParameter.From(cardService));
            //    return cardService;
            //}).As<ICardService>();
            // builder.Register(c => new CardService(c.Resolve<HttpContextBase>())).As<ICardService>().InstancePerRequest();
            //builder.Register(c => new LoggingCardService(c.Resolve<ICardService>())).As<ICardService>().InstancePerRequest();
            var container = builder.Build();
            // Set MVC DI resolver to use our Autofac container

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}