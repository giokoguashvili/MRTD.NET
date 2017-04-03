using System;
using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO8E : IDataObject, IBinary
    {
        private readonly IBinary _protectedResponseApdu;
        private readonly int _do8eBytesCountWithoutEncryptedData = 2;
        public ExtractedDO8E(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {

            //var extractedDO87AsString = new Hex(
            //                        new ExtractedDO87(_protectedResponseApdu)
            //                    ).ToString();
            //var extractedDO99AsString = new Hex(
            //                        new ExtractedDO99(_protectedResponseApdu)
            //                    ).ToString();

            var wrapped = new WrappedBerTLV(_protectedResponseApdu);
            var parsetBerTLV = new BerTLV(wrapped);
            return parsetBerTLV.Data.Where(tlv => tlv.T == "8E").First().Bytes();

            //return new BinaryHex(
            //    String.Concat(
            //            new Hex(_protectedResponseApdu)
            //                .ToString()
            //                .Replace(String.Format("{0}{1}", extractedDO87AsString, extractedDO99AsString), String.Empty)
            //                .Reverse()
            //                .Skip(4)
            //                .Reverse()
            //        )
            //).Bytes();
        }

        public IBinary EncryptedData()
        {
            return new Binary(
                    Bytes()
                        .Skip(_do8eBytesCountWithoutEncryptedData)
                );
                
        }
    }
}
