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
                        .Select(connectedReaderName => new ConnectedReader(
                                                            connectedReaderName,
                                                            _cardContext
                                                       ).Connected()
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
