using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.DataGroups.DG;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;

namespace HelloWord.DataGroups
{
    public class DG1 : IBinary
    {
        private readonly IReader _reader;
        private readonly IBinary _FID = new BinaryHex("0107");
        public DG1(
                IReader reader
            )
        {
            _reader = reader;
        }
        public byte[] Bytes()
        {
            return new DGData(
                        _FID,
                        _reader
                    ).Bytes();
        }
    }
}
