using HelloWord.Infrastructure;

namespace HelloWord.TVL.Cached
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
