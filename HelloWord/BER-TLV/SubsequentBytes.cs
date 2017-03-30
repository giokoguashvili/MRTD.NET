using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace HelloWord.BER_TLV
{
    // http://stackoverflow.com/questions/42450105/parsing-magtek-emv-tlv
    public class SubsequentBytes : IBinary
    {
        private readonly IBinary _berTag;
        private readonly byte _b5_b1_one = 0x1F; // 0b0001 0b1111
        private readonly byte _b8_one = 0x80; // 0b1000 0b0000
        public SubsequentBytes(IBinary berTag)
        {
            _berTag = berTag;
        }
        public byte[] Bytes()
        {
            var firstByte = _berTag.Bytes().First();
            var restBytes = _berTag.Bytes().Skip(1).ToArray();
            if (HasSubsequentBytes(firstByte))
            {
                return new ConcatenatedBinaries(
                            restBytes
                                .TakeWhile(IsSubsequentByte),
                            restBytes
                                .SkipWhile(IsSubsequentByte)
                                .Take(1)
                       ).Bytes();
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
