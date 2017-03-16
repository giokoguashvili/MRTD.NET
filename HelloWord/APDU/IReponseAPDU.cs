using HelloWord.Cryptography;

namespace HelloWord.APDU
{
    public interface IResponseAPDU : IBinary
    {
        IBinary Body();
        IBinary Trailer();
    }
}