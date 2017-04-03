using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.DataGroups.DG;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;
using HelloWord.SmartCard.Reader;

namespace HelloWord.DataGroups
{
    public class DG1 : IDataGroup<DG1Content>
    {
        private readonly IBacReader _bacReader;
        private readonly IBinary _fid = new BinaryHex("0107");
        public DG1(IBacReader bacReader)
        {
            _bacReader = bacReader;
        }
        public byte[] Bytes()
        {
            return _bacReader.DGData(_fid).Bytes();
        }

        public DG1Content Content()
        {
            return new DG1Content(_bacReader.DGData(_fid));
        }
    }
}
