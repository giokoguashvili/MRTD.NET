using HelloWord.Infrastructure;

namespace HelloWord.TVL.Cached
{
    public class CachedTag : IBinary
    {
        private readonly IBinary _cachedBerTag;

        public CachedTag(IBinary berTvl)
        {
            _cachedBerTag = new Infrastructure.Cached(
                                new Tag(berTvl)
                            );
        }
        public byte[] Bytes()
        {
            return _cachedBerTag.Bytes();
        }
    }
}
