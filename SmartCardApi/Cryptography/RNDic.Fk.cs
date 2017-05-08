using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class FkRNDic : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("4608F91988702212").Bytes();
        }
    }
}
