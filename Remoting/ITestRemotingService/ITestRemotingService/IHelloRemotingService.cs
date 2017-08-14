using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITestRemotingService
{
    public interface IHelloRemotingService
    {
        string GetMessage(string name);
    }
}
