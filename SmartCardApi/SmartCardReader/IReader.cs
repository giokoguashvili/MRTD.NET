using System;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCardReader
{
    public interface IReader : IDisposable
    {
        IBinary Transmit(IBinary rawCommandApdu);
    }
}
