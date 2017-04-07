using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Infrastructure
{
    public interface IOption<T> : IEnumerator<T>
    {
    }
}
