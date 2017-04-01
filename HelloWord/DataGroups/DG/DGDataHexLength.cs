using System.Linq;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;
using HelloWord.BER_TLV.TVL;
using System;

namespace HelloWord.DataGroups.DG
{
    public class DGDataHexLength : INumber
    {
        private readonly IBinary _applicationIdentifier;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        private readonly IReader _reader;

        private readonly INumber firstFourByteForDGStructureLength = new Number(5);

        public DGDataHexLength(
                IBinary applicationIdentifier,
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc,
                IReader reader
            )
        {
            _applicationIdentifier = applicationIdentifier;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
            _reader = reader;
        }

        public int Value()
        {
            var firstFourBytes = new SecureMessagingPipe(
                        _applicationIdentifier,
                        firstFourByteForDGStructureLength,
                        _kSenc,
                        _kSmac,
                        _ssc,
                        _reader
                   );

            var parsedBerTLV = new BerTLV(
                                    firstFourBytes
                                        .Bytes()
                                        .Take(firstFourByteForDGStructureLength.Value())
                                );

            var tagBytesCount = new HexCount(
                                    parsedBerTLV
                                        .T).Value();
            var lenBytesCount = new HexCount(parsedBerTLV.L).Value();

            return new ValLength(parsedBerTLV.L)
                                .Value() + tagBytesCount + lenBytesCount;
        }
    }
}
