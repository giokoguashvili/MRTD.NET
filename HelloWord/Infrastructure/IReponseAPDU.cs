using HelloWord.Cryptography;

namespace HelloWord.APDU
{
    public interface IResponseAPDU
    {
        IBinary Body();
        IBinary Trailer();
    }
}