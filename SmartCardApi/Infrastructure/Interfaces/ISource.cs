using System;

namespace SmartCardApi.Infrastructure.Interfaces
{
    public interface ISource<out TResult>
    {
        IObservable<TResult> Source();
    }
}
