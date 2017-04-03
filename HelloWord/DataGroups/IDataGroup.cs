using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace HelloWord.DataGroups
{
    public interface IDataGroup<TResult> : IBinary
    {
        TResult Content();
    }
}
