using System.Collections;
using System.Collections.Generic;
using PCSC;

namespace SmartCardApi.SmartCardReader
{
    public class ConnectedReaderNames : IEnumerable<string>
    {
        private readonly ISCardContext _cardContext;

        public ConnectedReaderNames(ISCardContext cardContext)
        {
            _cardContext = cardContext;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return ((IEnumerable<string>) _cardContext.GetReaders()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
