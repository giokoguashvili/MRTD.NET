using System;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCardReader
{
    public interface IBacReader: IDisposable
    {
        IBinary DGData(IBinary fid);
    }
}
