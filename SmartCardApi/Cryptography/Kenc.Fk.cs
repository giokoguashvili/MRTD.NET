using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class FkKenc : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("AB94FDECF2674FDFB9B391F85D7F76F2").Bytes();
        }
    }
}
