using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;
using PCSC;

namespace HelloWord.DataGroups
{
    public class COM : IBinary
    {
        private readonly IReader _reader;
        private readonly IBinary _kSenc;
        private readonly IBinary _kSmac;
        private readonly IBinary _incrementedSsc;

        public COM(
                IBinary kSenc,
                IBinary kSmac,
                IBinary incrementedSsc,
                IReader reader
            )
        {
            _reader = reader;
            _kSenc = kSenc;
            _kSmac = kSmac;
            _incrementedSsc = incrementedSsc;
        }
        public byte[] Bytes()
        {
            return new ExecutedCommandAPDU(
                        new ProtectedCommandApdu(
                            new SelectEFCOMApplicationCommand(),
                            _kSenc,
                            _kSmac,
                            new IncrementedSSC(
                                _incrementedSsc
                            )
                        ), 
                        _reader
                    ).Bytes();
        }
    }
}
