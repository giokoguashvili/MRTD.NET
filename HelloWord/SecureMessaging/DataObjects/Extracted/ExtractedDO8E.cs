using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO8E : IBinary
    {
        private readonly IBinary _protectedResponseApdu;

        public ExtractedDO8E(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {

            var extractedDO87AsString = new Hex(
                                    new ExtractedDO87(_protectedResponseApdu)
                                ).ToString();
            var extractedDO99AsString = new Hex(
                                    new ExtractedDO99(_protectedResponseApdu)
                                ).ToString();

            return new BinaryHex(
                String.Concat(new Hex(_protectedResponseApdu)
                    .ToString()
                    .Replace(String.Format("{0}{1}", extractedDO87AsString, extractedDO99AsString), String.Empty)
                    .Reverse()
                    .Skip(4)
                    .Reverse())
            ).Bytes();
        }
    }
}
