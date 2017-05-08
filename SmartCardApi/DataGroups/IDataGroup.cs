using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.DataGroups
{
    public interface IDataGroup<TResult> : IBinary
    {
        TResult Content();
    }
}
