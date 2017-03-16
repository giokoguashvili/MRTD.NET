using HelloWord.Cryptography;
using PCSC;
using PCSC.Iso7816;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWord.APDU
{
    public interface ICommandAPDU : IBinary
    {
        IsoCase Case();
        SCardProtocol Protocol();
        int ExceptedDataLength();
    }
}
