using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.TVL.L
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
