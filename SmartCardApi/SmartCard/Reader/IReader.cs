using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard.Reader
{
    public interface IReader
    {
        IBinary Transmit(IBinary rawCommandApdu);
    }
}
