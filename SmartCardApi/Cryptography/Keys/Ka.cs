using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography.Keys
{
    public class Ka : IBinary
    {
        private readonly IBinary _kKey;
        public Ka(IBinary kKey)
        {
            _kKey = kKey;
        }
        public byte[] Bytes()
        {
            return new AdjustedParity(
                        _kKey
                            .Bytes()
                            .Skip(0)
                            .Take(8)
                            .ToArray()
                    ).Bytes();
        }
    }
}
