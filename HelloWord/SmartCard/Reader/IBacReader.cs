using HelloWord.Infrastructure;

namespace HelloWord.SmartCard.Reader
{
    public interface IBacReader
    {
        IBinary DGData(IBinary fid);
    }
}
