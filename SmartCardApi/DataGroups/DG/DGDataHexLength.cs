using SmartCardApi.Infrastructure;
using SmartCardApi.SecureMessaging.Pipe;
using SmartCardApi.SmartCard.Reader;
using SmartCardApi.TVL.V;

namespace SmartCardApi.DataGroups.DG
{
    public class DGDataHexLength : INumber
    {
        private readonly IBerTLV _berTlv;
        private readonly INumber _minTlvHeaderLength = new Number(5);

        public DGDataHexLength(
                IBinary applicationIdentifier,
                IReader securedReader
            )
        {
            _berTlv = new BerTLV(
                        new Cached(
                            new SecureMessagingPipe(
                                applicationIdentifier,
                                _minTlvHeaderLength,
                                securedReader
                            )
                         )
                    );
        }

        public int Value()
        {
            var sum = new Sum(
                        new BytesCount(_berTlv.TL),
                        new ValLength(_berTlv.L)
                    ).Value();
            return sum;
        }
    }
}
