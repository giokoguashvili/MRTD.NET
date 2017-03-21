using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.CommandAPDU
{
    public interface ICommandAPDU : IBinary
    {
        IsoCase Case();
        SCardProtocol Protocol();
        int ExceptedDataLength();
    }
}
