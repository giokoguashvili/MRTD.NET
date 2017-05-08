using System;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SmartCardReader
{
    public interface IReader : IDisposable
    {
        IBinary Transmit(IBinary rawCommandApdu);
    }
}
