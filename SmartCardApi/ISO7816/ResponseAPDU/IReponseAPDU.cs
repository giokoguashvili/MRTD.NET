using SmartCardApi.Infrastructure;

namespace SmartCardApi.ISO7816.ResponseAPDU
{
    public interface IResponseApdu
    {
        IBinary Body();
        IBinary Trailer();
    }
}