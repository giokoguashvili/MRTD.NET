using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.ISO7816.ResponseAPDU
{
    public interface IResponseApdu
    {
        IBinary Body();
        IBinary Trailer();
    }
}