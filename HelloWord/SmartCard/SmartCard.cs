using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.DataGroups;
using HelloWord.SmartCard.Reader;

namespace HelloWord.SmartCard
{
    public class SmartCard
    {
        private readonly IBacReader _bacReader;

        public SmartCard(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }

        public DG1 DG1()
        {
            return new DG1(_bacReader);
        }
    }
}
