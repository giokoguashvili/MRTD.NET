using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PCSC;

namespace HelloWord.SmartCard
{
    public interface IReader
    {
        SCardError Transmit(IntPtr sendPci, byte[] sendBuffer, SCardPCI receivePci, ref byte[] receiveBuffer);
        SCardProtocol ActiveProtocol();
    }
}
