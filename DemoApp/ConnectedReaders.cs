using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PCSC;

namespace SmartCardApi.SmartCard.Reader
{
    public class ConnectedReaders : IEnumerable<IReader>
    {
        private readonly ISCardContext _cardContext;

        public ConnectedReaders(ISCardContext cardContext)
        {
            _cardContext = cardContext;
        }
        public IEnumerator<IReader> GetEnumerator()
        {
            return new ConnectedReaderNames(_cardContext)
                        .Where(rn => !rn.Contains("JAVA"))
                        .SelectMany(connectedReaderName => new ConnectedReader(
                                                                connectedReaderName,
                                                                _cardContext
                                                           )
                        )
                        .ToList()
                        .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
