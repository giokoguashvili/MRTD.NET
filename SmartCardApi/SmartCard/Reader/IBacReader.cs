using System;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard.Reader
{
    public interface IBacReader: IDisposable
    {
        IBinary DGData(IBinary fid);
    }
}
