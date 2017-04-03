using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace HelloWord.SmartCard
{
    public interface IBacReader
    {
        IBinary DGData(IBinary fid);
    }
}
