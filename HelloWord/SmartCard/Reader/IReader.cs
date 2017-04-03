using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;
using PCSC;

namespace HelloWord.SmartCard
{
    public interface IReader
    {
        IBinary Transmit(IBinary rawCommandApdu);
    }
}
