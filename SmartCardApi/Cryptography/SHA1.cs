using System.Security.Cryptography;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class SHA1 : IBinary
    {
        private readonly IBinary _binary;

        public SHA1(IBinary binary)
        {
            _binary = binary;
        }

        public byte[] Bytes()
        {
            return new SHA1Managed()
                .ComputeHash(_binary.Bytes());
        }
    }
}
