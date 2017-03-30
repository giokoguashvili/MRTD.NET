using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.BER_TLV
{
    public interface IBerTLV
    {
        string Tag { get; }
        string Len { get; }
        string Val { get; }
        IBerTLV[] Data { get; }
    }
}
