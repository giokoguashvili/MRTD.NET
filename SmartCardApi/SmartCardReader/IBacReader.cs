using System;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SmartCardReader
{
    public interface IBacReader: IDisposable
    {
        IBinary DGData(IBinary fid);
    }
}
