using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.TVL.L
{
    public class ShortLen : IBinary
    {
        private readonly IBinary _berTlvWithoutTag;
        public ShortLen(IBinary berTvlWithoutTag)
        {
            _berTlvWithoutTag = berTvlWithoutTag;
        }
        public byte[] Bytes()
        {
            return _berTlvWithoutTag
                        .Bytes()
                        .Take(1)
                        .ToArray();
        }
    }
}
