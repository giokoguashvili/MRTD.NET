using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.DataGroups.DG;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.Pipe;

namespace HelloWord.SmartCard
{
    public class BacReader : IBacReader
    {
        private readonly IReader _securedReader;

        public BacReader(IReader securedReader)
        {
            _securedReader = securedReader;
        }

        public IBinary DGData(IBinary fid)
        {
            return new DGData(
                    fid,
                    _securedReader
                );
        }
    }
}
