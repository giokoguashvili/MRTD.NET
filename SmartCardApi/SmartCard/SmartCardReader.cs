using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard
{
    public class SmartCardReader
    {
        private readonly ISymbols _mrzInfo;

        public SmartCardReader(ISymbols mrzInfo)
        {
            _mrzInfo = mrzInfo;
        }

        public void WhenCardInserted(Action<SmartCard> callback)
        {

        }
    }
}
