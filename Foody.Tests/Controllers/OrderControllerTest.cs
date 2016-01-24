using Foody.Controllers;
using Foody.Models;
using Foody.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;

namespace Foody.Tests.Controllers
{
    public class MockHttpSession : HttpSessionStateBase
    {
        // Started with sample http://stackoverflow.com/questions/524457/how-do-you-mock-the-session-object-collection-using-moq
        // from http://stackoverflow.com/users/81730/ronnblack

        Dictionary<string, object> _sessionStorage = new Dictionary<string, object>();
        public override object this[string name]
        {
            get {
                if(_sessionStorage.ContainsKey(name))
                    return _sessionStorage[name];
                return null;
            }
            set {
                _sessionStorage[name] = value;
            }
        }

        public override void Add(string name, object value)
        {
            _sessionStorage[name] = value;
        }
    }
    public static class MvcMockHelpers
    {
        public static HttpContextBase FakeHttpContext()
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var response = new Mock<HttpResponseBase>();
            var session = new MockHttpSession();
            var server = new Mock<HttpServerUtilityBase>();

            context.Setup(ctx => ctx.Request).Returns(request.Object);
            context.Setup(ctx => ctx.Response).Returns(response.Object);
            context.Setup(ctx => ctx.Session).Returns(session);
            context.Setup(ctx => ctx.Server).Returns(server.Object);

            return context.Object;


        }

        public static HttpContextBase FakeHttpContext(string url)
        {
            HttpContextBase context = FakeHttpContext();
            context.Request.SetupRequestUrl(url);
            return context;
        }

        public static void SetFakeControllerContext(this Controller controller)
        {
            var httpContext = FakeHttpContext();
            ControllerContext context = new ControllerContext(new System.Web.Routing.RequestContext(httpContext, new RouteData()), controller);
            controller.ControllerContext = context;
        }

        static string GetUrlFileName(string url)
        {
            if (url.Contains("?"))
                return url.Substring(0, url.IndexOf("?"));
            else
                return url;
        }

        static NameValueCollection GetQueryStringParameters(string url)
        {
            if (url.Contains("?"))
            {
                NameValueCollection parameters = new NameValueCollection();

                string[] parts = url.Split("?".ToCharArray());
                string[] keys = parts[1].Split("&".ToCharArray());

                foreach (string key in keys)
                {
                    string[] part = key.Split("=".ToCharArray());
                    parameters.Add(part[0], part[1]);
                }

                return parameters;
            }
            else
            {
                return null;
            }
        }

        public static void SetHttpMethodResult(this HttpRequestBase request, string httpMethod)
        {
            Mock.Get(request)
                .Setup(req => req.HttpMethod)
                .Returns(httpMethod);
        }

        public static void SetupRequestUrl(this HttpRequestBase request, string url)
        {
            if (url == null)
                throw new ArgumentNullException("url");
            if (!url.StartsWith("~/"))
                throw new ArgumentException("Sorry, we expect a virtual url starting with \"~/\".");

            var mock = Mock.Get(request);

            mock.Setup(req => req.QueryString)
                .Returns(GetQueryStringParameters(url));
            mock.Setup(req => req.AppRelativeCurrentExecutionFilePath)
                .Returns(GetUrlFileName(url));
            mock.Setup(req => req.PathInfo)
                .Returns(string.Empty);
        }
    }

    public class apiClientProvider
    {
        string _hostUri;
        public string AccessToken { get; private set; }

        public apiClientProvider(string hostUri)
        {
            _hostUri = hostUri;
        }


        public async Task<Dictionary<string, string>> GetTokenDictionary(
            string userName, string password)
        {
            HttpResponseMessage response;
            var pairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>( "grant_type", "password" ),
                    new KeyValuePair<string, string>( "username", userName ),
                    new KeyValuePair<string, string> ( "password", password )
                };
            var content = new FormUrlEncodedContent(pairs);

            using (var client = new HttpClient())
            {
                var tokenEndpoint = new Uri(new Uri(_hostUri), "Token");
                response = await client.PostAsync(tokenEndpoint, content);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(string.Format("Error: {0}", responseContent));
            }

            return GetTokenDictionary(responseContent);
        }


        private Dictionary<string, string> GetTokenDictionary(
            string responseContent)
        {
            Dictionary<string, string> tokenDictionary =
                JsonConvert.DeserializeObject<Dictionary<string, string>>(
                responseContent);
            return tokenDictionary;
        }
    }


    [TestClass]
    public class OrderControllerTest
    {
        
        //[TestMethod]
        //public void TestAddOrder()
        //{
        //    log4net.Config.XmlConfigurator.Configure(new FileInfo(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile));
        //    CardService cardService = new CardService(MvcMockHelpers.FakeHttpContext());
        //    OrderController controller = new OrderController(new LoggingCardService(cardService));
        //    controller.AddDish(new Dish());
        //    ViewResult result = controller.GetNumberOfDishes() as ViewResult;
        //    Assert.AreEqual(1, result.Model);
        //}

        //[TestMethod]
        //public void TestFakeHttpContext()
        //{
        //    HttpContextBase httpContext = MvcMockHelpers.FakeHttpContext();
        //    httpContext.Session["session"]="session";
        //    Assert.AreEqual(httpContext.Session["session"], "session");
        //}

        //[TestMethod]
        //public void IntergrationTestAddOrder()
        //{

        //}
    } 
}
