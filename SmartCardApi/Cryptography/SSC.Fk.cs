using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class FkSSC : IBinary
    {
        public byte[] Bytes()
        { 
            return new BinaryHex("887022120C06C226").Bytes();
        }
    }
}
