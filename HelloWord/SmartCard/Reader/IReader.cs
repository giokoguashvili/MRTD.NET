using HelloWord.Infrastructure;

namespace HelloWord.SmartCard.Reader
{
    public interface IReader
    {
        IBinary Transmit(IBinary rawCommandApdu);
    }
}
