using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;

namespace SmartCardApi.Infrastructure.Interfaces
{
    public interface IState<out TResult>
    {
        TResult Next();
    }
}
