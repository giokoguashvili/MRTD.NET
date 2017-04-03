using System.Linq;
using HelloWord.Infrastructure;

namespace HelloWord.TVL.T
{
  
    public class Tag : IRest, IBinary
    {
        private readonly IBinary _berTlv;
        private readonly IBinary _tag;
        public Tag(IBinary berTlv)
        {
            _berTlv = berTlv;
            _tag = new CombinedBinaries(
                        new Binary(berTlvFirstByte()),
                        new TagSubsequentBytes(_berTlv)
                    );
        }
        public byte[] Bytes()
        {
            return _tag.Bytes();
        }

        private byte berTlvFirstByte()
        {
            return _berTlv.Bytes().First();
        }

        public IBinary Rest()
        {
            return new Binary(
                        _berTlv
                            .Bytes()
                            .Skip(new BytesCount(_tag).Value())
                   );
        }
    }
}
