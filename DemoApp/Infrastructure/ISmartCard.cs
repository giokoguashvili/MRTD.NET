using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.DataGroups;

namespace DemoApp.Infrastructure
{
    public interface ISmartCard
    {
        DG1 DG1();
        DG2 DG2();
        DG7 DG7();
        DG11 DG11();
        DG12 DG12();
    }
}
