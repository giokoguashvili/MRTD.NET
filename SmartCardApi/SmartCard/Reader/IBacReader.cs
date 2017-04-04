using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard.Reader
{
    public interface IBacReader
    {
        IBinary DGData(IBinary fid);
    }
}
