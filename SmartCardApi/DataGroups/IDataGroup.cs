using SmartCardApi.Infrastructure;

namespace SmartCardApi.DataGroups
{
    public interface IDataGroup<TResult> : IBinary
    {
        TResult Content();
    }
}
