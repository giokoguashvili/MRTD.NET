using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO99 : IBinary
    {
        private readonly IBinary _protectedResponseApdu;

        public ExtractedDO99(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
           

            var extractedDO87AsString = new Hex(
                                    new ExtractedDO87(_protectedResponseApdu)
                                ).ToString();

            var hex = new Hex(_protectedResponseApdu)
                .ToString();
            var replaced = hex;
            if (extractedDO87AsString != String.Empty)
            {
                replaced = hex.Replace(extractedDO87AsString, String.Empty);
            }


            if (replaced.StartsWith("9902") == false)
            {
                return new Binary().Bytes();
            }

            return new BinaryHex(
                   String.Concat(
                            replaced
                            .Take(8)
                        )
            ).Bytes();
        }
    }
}
