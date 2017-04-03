using System.Linq;
using HelloWord.Infrastructure;
using System;

namespace HelloWord.SecureMessaging.DataObjects.Extracted
{
    public class ExtractedDO87 : IDataObject, IBinary
    {
        private readonly IBinary _protectedResponseApdu;
        private readonly int _do87BytesCountWithoutEncryptedData = 3;

        public ExtractedDO87(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            //if (new Hex(
            //        new Binary(
            //            _protectedResponseApdu
            //                .Bytes()
            //                .Take(1)
            //        )
            //    ).ToString() != "87")
            //{
            //    return new Binary().Bytes();
            //}

            //var L = _protectedResponseApdu
            //    .Bytes()
            //    .Skip(1)
            //    .Take(1)
            //    .First();

            //var encDataLength = new Hex(
            //                        new Binary(
            //                            new[] { L }
            //                        )
            //                    ).ToInt() - 1;

            if (_protectedResponseApdu.Bytes().Length == 0)
            {
                var gio = 6;
            }
            try
            {
                var wrapped = new WrappedBerTLV(_protectedResponseApdu);
              
                var parsetBerTLV = new BerTLV(wrapped);
                if (parsetBerTLV.Data.Where(tlv => tlv.T == "87").Count() == 0)
                    return new Binary().Bytes();
                return parsetBerTLV.Data.Where(tlv => tlv.T == "87").First().Bytes().ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(new Hex(new WrappedBerTLV(_protectedResponseApdu).Bytes()));
                var gio = 5;
            }
            return new Binary().Bytes();
            //return new Binary(
            //        _protectedResponseApdu
            //            .Bytes()
            //            .Take(_do87BytesCountWithoutEncryptedData + encDataLength)
            //            .ToArray()
            //    ).Bytes();
        }

        public IBinary EncryptedData()
        {
            if (Bytes().Length == 0) return new Binary();
           // var x = new Binary(new BinaryHex(new BerTLV(new Binary().Bytes()).V).Bytes().Skip(1));
            return new Binary(new BinaryHex(new BerTLV(
                Bytes()
            ).V).Bytes().Skip(1));
            //var str = new Hex(new BinaryHex(new BerTLV(
            //    Bytes()
            //).V).Bytes().Skip(1)).ToString();
            //var str2 = new Hex(new Binary(
            //    Bytes()
            //        .Skip(_do87BytesCountWithoutEncryptedData)
            //)).ToString();
            //return new Binary(
            //    Bytes()
            //        .Skip(_do87BytesCountWithoutEncryptedData)
            //);
            //return new BinaryHex(new BerTLV(
            //    Bytes()
            //).V);
        }
    }
}
