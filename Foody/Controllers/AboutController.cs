using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace Foody.Controllers
{
    public class AboutController : Controller
    {
        [Route("About/test")]
        public ActionResult About()
        {
            //A a = new A();
            ////A.A1 = 10;
            ////A b = new A();
            ////A a = new A();
            ////a.x = 10;
            //test(ref a);

            //int number = 1;
            //int value = AddTen(out number);

            //AuthorAttribute MyAttribute =
            //(AuthorAttribute)Attribute.GetCustomAttribute(a.GetType(), typeof(AuthorAttribute));

            //B bObj = new B(2);

            return View();
        }

        public ActionResult Difference()
        {
            return View();
        }

        //public void test(ref A a1)
        //{
        //    a1.x = 11;
        //}

        //int AddTen(out int number)  // parameter is passed by value
        //{
        //    number = 10;
        //    return number;
        //}


    }

    public class A
    {
        public A()
        {
            Debug.WriteLine("Hi you are in class A");
        }

        public A(int x)
        {

        }
    }

    public class B : A
    {
        public B()
        {
            Debug.WriteLine("Hi you are in class B");
        }
    }
    //[Author("P. Ackerman", version = 1.1)]
    //public class A
    //{
    //    public static int A1;
    //    public int x;
    //}

    //[System.AttributeUsage(System.AttributeTargets.Class |
    //                   System.AttributeTargets.Struct)
    //]
    //public class AuthorAttribute : System.Attribute
    //{
    //    private string name;
    //    public double version;

    //    public AuthorAttribute(string name)
    //    {
    //        this.name = name;
    //        version = 1.0;
    //    }
    //}

    /// test
}
