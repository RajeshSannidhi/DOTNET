using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRemotingService
{
    public class HelloRemotingService : MarshalByRefObject, ITestRemotingService.IHelloRemotingService
    {
        public string GetMessage(string name)
        {
            return "Hello " + name;
        }
    }
}
