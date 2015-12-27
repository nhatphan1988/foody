using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Foody;
using Foody.Controllers;
using Moq;
using FoodyDomain;
using FoodyDomain.Model;
using Autofac;
using FoodyRespository.Respository;

namespace Foody.Tests.Controllers
{
    [TestClass]
    public class MenuControllerTest
    {
        [TestMethod]
        public void _MenuPartial()
        {
            //Mock<IResponsitory<MenuEntity>> menuResponsitory = new Mock<IResponsitory<MenuEntity>>();
            //var builder = new ContainerBuilder();
            //builder.RegisterType<MenuResponsitory>().As<IResponsitory<MenuEntity>>();
            //var container = builder.Build();

            //using (var scope = container.BeginLifetimeScope())
            //{
            // var service = scope.Resolve<MenuResponsitory>();
            Mock<IResponsitory<MenuEntity>> menuResponsitory = new Mock<IResponsitory<MenuEntity>>();
            menuResponsitory.SetupGet(f => f.List).Returns(new List<MenuEntity> { new MenuEntity {
                Name = "Bo bia"
            } });

            //MenuController controller = new MenuController(menuResponsitory.Object);
            //    // Act
            //    PartialViewResult result = controller._MenuPartial() as PartialViewResult;
            //    var menus = (List<MenuEntity>)result.Model;
            //    // Assert
            //    Assert.AreEqual("_MenuPartial", result.ViewName);
            //    Assert.AreEqual("Bo bia", menus.FirstOrDefault().Name);
            ////}

        }
    }
}
