using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foody.Tests.Controllers
{
    class Class1
    {
        
        [BeforeEach]
        public int MyProperty { get; set; }
        public void A()
        {
            Moq.Mock<Class1> moq = new Moq.Mock<Class1>();
            moq.Setup(f => f.MyProperty).Returns(0);

        }
    }
}
