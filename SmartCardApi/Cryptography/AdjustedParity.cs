using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class AdjustedParity : IBinary
    {
        private readonly byte[] _bites;

        public AdjustedParity(byte[] bites)
        {
            _bites = bites;
        }
        public AdjustedParity(IBinary binary) : this(binary.Bytes()) { }
        public byte[] Bytes()
        {
            return _bites
               .Select(b => new Parity(b).Adjusted().Result())
               .ToArray();
        }
    }
}
