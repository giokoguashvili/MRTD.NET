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
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _ssc;
        private readonly IBinary _FID = new BinaryHex("010B");
        public DG1(
                IBinary kSenc,
                IBinary kSmac,
                IBinary ssc,
                IReader reader
            )
        {
            _reader = reader;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _ssc = ssc;
        }
        public byte[] Bytes()
        {
            return new DGData(
                        _FID,
                        _kSenc,
                        _kSmac,
                        _ssc,
                        _reader
                    ).Bytes();
        }
    }
}
