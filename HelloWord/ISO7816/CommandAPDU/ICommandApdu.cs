using HelloWord.Infrastructure;
using PCSC;
using PCSC.Iso7816;

namespace HelloWord.ISO7816.CommandAPDU
{
    public interface ICommandApdu : IBinary
    {
        IsoCase Case();
        SCardProtocol ActiveProtocol();
        int ExceptedDataLength();
    }
}
