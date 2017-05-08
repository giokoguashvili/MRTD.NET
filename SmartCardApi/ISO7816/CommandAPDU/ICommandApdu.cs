using PCSC;
using PCSC.Iso7816;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.ISO7816.CommandAPDU
{
    public interface ICommandApdu : IBinary
    {
        IsoCase Case();
        SCardProtocol ActiveProtocol();
        int ExceptedDataLength();
    }
}
