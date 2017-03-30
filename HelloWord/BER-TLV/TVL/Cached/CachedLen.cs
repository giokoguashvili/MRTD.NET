using HelloWord.Infrastructure;

namespace HelloWord.BER_TLV
{
    public class CachedLen : IBinary
    {
        private readonly IBinary _cachedBerLen;
        public CachedLen(IBinary berTvl, IBinary berTag)
        {
            _cachedBerLen = new Cached(
                                new Len(berTvl, berTag)
                            );
        }
        public byte[] Bytes()
        {
            return _cachedBerLen.Bytes();
        }
    }
}
