using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class DESKeys : IKeys
    {
        private readonly IBinary _binary;
        public DESKeys(IBinary binary)
        {
            _binary = binary;
        }

        public IBinary Ka()
        {
            return new AdjustedParity(
                    _binary
                        .Bytes()
                        .Take(8)
                        .ToArray()
                );
        }

        public IBinary Kb()
        {
            return new AdjustedParity(
                    _binary
                        .Bytes()
                        .Skip(8)
                        .Take(8)
                        .ToArray()
                );
        }

        public IBinary Key()
        {
            return new AdjustedParity(
                    _binary
                        .Bytes()
                        .Take(16)
                        .ToArray()  
                );
        }
    }
}
