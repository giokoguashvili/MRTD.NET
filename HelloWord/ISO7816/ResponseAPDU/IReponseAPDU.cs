using HelloWord.Infrastructure;

namespace HelloWord.ISO7816.ResponseAPDU
{
    public interface IResponseApdu
    {
        IBinary Body();
        IBinary Trailer();
    }
}