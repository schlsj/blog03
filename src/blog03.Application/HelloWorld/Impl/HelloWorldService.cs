using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blog03.HelloWorld.Impl
{
    public class HelloWorldService : blog03AppService, IHelloWorldService
    {
        public string HelloWorld()
        {
            return "Hello World";
        }
    }
}
