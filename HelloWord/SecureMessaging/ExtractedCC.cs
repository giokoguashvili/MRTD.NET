using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DataObjects.Extracted;

namespace HelloWord.SecureMessaging
{
    public class ExtractedCC : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IBinary _protectedResponseApdu;

        public ExtractedCC(
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary protectedResponseApdu
            )
        {
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            return new CC(
                _incrementedSsc,
                _kSmac,
                new ConcatenatedBinaries(
                    new ExtractedDO87(_protectedResponseApdu),
                    new ExtractedDO99(_protectedResponseApdu)
                )
            ).Bytes();
        }
    }
}
