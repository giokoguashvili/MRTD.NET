using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartCardApi.USB
{
    public class USB 
    {
        private readonly Action _func;

        public USB(Action func)
        {
            _func = func;
        }

        public void Run()
        {
            
        }
    }
}
