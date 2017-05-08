using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class FkKifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("0B795240CB7049B01C19B33E32804F0B").Bytes();
        }
    }
}
