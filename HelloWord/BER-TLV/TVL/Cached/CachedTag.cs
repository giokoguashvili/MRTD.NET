using HelloWord.Infrastructure;

namespace HelloWord.BER_TLV
{
    public class CachedTag : IBinary
    {
        private readonly IBinary _cachedBerTag;

        public CachedTag(IBinary berTvl)
        {
            _cachedBerTag = new Cached(
                                new Tag(berTvl)
                            );
        }
        public byte[] Bytes()
        {
            return _cachedBerTag.Bytes();
        }
    }
}
