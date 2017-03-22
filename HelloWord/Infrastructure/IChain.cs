using HelloWord.ISO7816.CommandAPDU;
using HelloWord.SmartCard;

namespace HelloWord.Infrastructure
{
    public interface IChain
    {
        IBinary Enclosed(IReader reader);
    }

    public interface ICommandApduFactory
    {
        ICommandApdu Command();
    }
}