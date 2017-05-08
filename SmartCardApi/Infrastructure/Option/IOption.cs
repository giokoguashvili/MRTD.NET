using System.Collections.Generic;

namespace SmartCardApi.Infrastructure.Option
{
    public interface IOption<out T> : IEnumerator<T>
    {
    }
}
