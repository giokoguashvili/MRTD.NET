using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord
{
    // http://stackoverflow.com/questions/42450105/parsing-magtek-emv-tlv
    public class TagSubsequentBytes : IBinary
    {
        private readonly IBinary _berTvl;
        private readonly byte _b5_b1_one = 0x1F; // 0b0001 0b1111
        private readonly byte _b8_one = 0x80; // 0b1000 0b0000
        public TagSubsequentBytes(IBinary berTvl)
        {
            _berTvl = berTvl;
        }
        public byte[] Bytes()
        {
            var firstByte = _berTvl.Bytes().FirstOrDefault();
            var restBytes = _berTvl.Bytes().Skip(1).ToArray();
            if (HasSubsequentBytes(firstByte))
            {
                return restBytes
                    .TakeWhileWithIncludingLast(IsSubsequentByte)
                    .ToArray();
            }

            return new byte[0];
        }

        private bool IsSubsequentByte(byte berTagByte)
        {
            return (berTagByte & _b8_one) == _b8_one;
        }

        private bool HasSubsequentBytes(byte berTagFirstByte)
        {
            return (berTagFirstByte & _b5_b1_one) == _b5_b1_one;
        }
    }
}
