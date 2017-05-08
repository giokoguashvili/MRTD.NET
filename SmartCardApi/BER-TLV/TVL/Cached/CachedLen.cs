using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.TVL.L;

namespace SmartCardApi.TVL.Cached
{
    public class CachedLen : IBinary
    {
        private readonly IBinary _cachedBerLen;
        public CachedLen(IBinary berTvl, IBinary berTag)
        {
            _cachedBerLen = new Infrastructure.Cached(
                                new Len(berTvl, berTag)
                            );
        }
        public byte[] Bytes()
        {
            return _cachedBerLen.Bytes();
        }
    }
}
