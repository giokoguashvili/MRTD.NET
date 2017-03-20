using PCSC;
using PCSC.Iso7816;

namespace HelloWord.Infrastructure
{
    public interface ICommandAPDU : IBinary
    {
        IsoCase Case();
        SCardProtocol Protocol();
        int ExceptedDataLength();
    }
}
