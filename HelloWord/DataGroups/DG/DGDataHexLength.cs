using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;
using System;
using HelloWord.SecureMessaging.Pipe;
using HelloWord.TVL.V;

namespace HelloWord.DataGroups.DG
{
    public class DGDataHexLength : INumber
    {
        private readonly IBerTLV _berTlv;
        private readonly INumber _minTlvHeaderLength = new Number(5);

        public DGDataHexLength(
                IBinary applicationIdentifier,
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc,
                IReader reader
            )
        {
            _berTlv = new BerTLV(
                        new Cached(
                            new SecureMessagingPipe(
                                applicationIdentifier,
                                _minTlvHeaderLength,
                                kSenc,
                                kSmac,
                                ssc,
                                reader
                            )
                         )
                    );
        }

        public int Value()
        {
            return new Sum(
                        new BytesCount(_berTlv.TL),
                        new ValLength(_berTlv.L)
                    ).Value();
        }
    }
}
