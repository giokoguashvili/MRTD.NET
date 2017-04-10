using System;

namespace SmartCardApi.Infrastructure
{
    public interface ISource<out TResult>
    {
        IObservable<TResult> Source();
    }
}
