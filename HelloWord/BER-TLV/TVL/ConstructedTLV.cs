using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.TVL
{
    public class ConstructedTLV
    {
        private readonly IBinary _constructedTLV;
        private readonly IBinary _cachedFirstExistingTLV;

        public ConstructedTLV(IBinary constructedTLV)
        {
            _constructedTLV = constructedTLV;
            _cachedFirstExistingTLV = new BerTLV(_constructedTLV);
        }

        private IBerTLV[] First()
        {
            return new IBerTLV[] { new BerTLV(_cachedFirstExistingTLV) };
        }

        private IBinary Rest()
        {
            return new Binary(
                        _constructedTLV
                            .Bytes()
                            .Skip(_cachedFirstExistingTLV.Bytes().Length)
                    );
        }

        public IBerTLV[] Data()
        {
            if (new BytesCount(Rest()).IsEmpty())
            {
                return First();
            }
            return First()
                .Concat(
                    new ConstructedTLV(
                        Rest()
                    ).Data()
                ).ToArray();
        }
    }
}
