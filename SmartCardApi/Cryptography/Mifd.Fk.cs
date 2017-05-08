using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class FkMifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("5F1448EEA8AD90A7").Bytes();
        }
    }
}
