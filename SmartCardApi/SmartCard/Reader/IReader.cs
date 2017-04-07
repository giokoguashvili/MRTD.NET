using System;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard.Reader
{
    public interface IReader : IDisposable
    {
        IBinary Transmit(IBinary rawCommandApdu);
    }
}
