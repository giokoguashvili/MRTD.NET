using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class FkRNDifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("781723860C06C226").Bytes();
        }
    }
}
