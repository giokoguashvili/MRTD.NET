using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography.Keys
{
    public class Kb : IBinary
    {
        private readonly IBinary _kKey;
        public Kb(IBinary kKey)
        {
            _kKey = kKey;
        }
        public byte[] Bytes()
        {
            return new AdjustedParity(
                        _kKey
                            .Bytes()
                            .Skip(8)
                            .Take(8)
                            .ToArray()
                    ).Bytes();
        }
    }
}
