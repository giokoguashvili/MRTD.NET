using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.TVL.L
{
    public class LongLen : IBinary
    {
        private readonly IBinary _berTvlWithoutTag;
        private readonly byte _b7_b1_one = 0x7F;// 0b0111 0b1111
        public LongLen(IBinary berTvlWithoutTag)
        {
            _berTvlWithoutTag = berTvlWithoutTag;
        }
        public byte[] Bytes()
        {
            var firstByte = _berTvlWithoutTag.Bytes().First();
            var valueByteCount = new Hex(ExtractLen(firstByte)).ToInt();
            return _berTvlWithoutTag
                        .Bytes()
                        .Skip(1)
                        .Take(valueByteCount)
                        .ToArray();
        }

        private byte[] ExtractLen(byte firstByteOfBerTvlWithoutTag)
        {
            return new[] { (byte)(firstByteOfBerTvlWithoutTag & _b7_b1_one) };
        }
    }
}
