using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSC;

namespace SmartCardApi.SmartCard
{
    public class ReaderFactory
    {
        private ISCardContext _cardContext;
        private ISCardContext CardContext
        {
            get
            {
                if (_cardContext == null)
                {
                    _cardContext = ContextFactory.Instance.Establish(SCardScope.System);
                }
                return _cardContext;
            }
        }
        public ISCardReader ConnectedReader(string readerName)
        {
            var reader = new SCardReader(CardContext);
            var sc = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.T1);
            return reader;
        }
    }
}
