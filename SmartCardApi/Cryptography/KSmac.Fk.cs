using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class FkKSmac : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8").Bytes();
        }
    }
}
