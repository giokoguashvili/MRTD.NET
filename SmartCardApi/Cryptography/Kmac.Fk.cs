using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class FkKmac : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("7962D9ECE03D1ACD4C76089DCE131543").Bytes();
        }
    }
}
