using HelloWord.Infrastructure;

namespace HelloWord.TVL.Cached
{
    public class CachedVal : IBinary
    {
        private readonly IBinary _cachedBerVal;
        public CachedVal(
                IBinary berTvl,
                IBinary berTag,
                IBinary berLen
            )
        {
            _cachedBerVal = new Infrastructure.Cached(
                                new Val(berTvl, berTag, berLen)
                            );
        }
        public byte[] Bytes()
        {
            return _cachedBerVal.Bytes();
        }
    }
}
