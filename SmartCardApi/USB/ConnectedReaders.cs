using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSC;

namespace SmartCardApi.USB
{
    public class ConnectedReaders : IEnumerable<ISCardReader>
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

        public ConnectedReaders()
        {
            var contextFactory = ContextFactory.Instance;
            var context = contextFactory.Establish(SCardScope.System);


            var readerNames = context.GetReaders();
            foreach (var readerName in readerNames)
            {
                Console.WriteLine(readerName);
            }

        }
        public IEnumerator<ISCardReader> GetEnumerator()
        {
            foreach (var readerName in CardContext.GetReaders())
            {
                var reader = new SCardReader(CardContext);
                reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.T1);
                yield return reader;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
