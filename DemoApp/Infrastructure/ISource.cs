using System;

namespace DemoApp.Infrastructure
{
    public interface ISource<out TResult>
    {
        IObservable<TResult> Source();
    }
}
