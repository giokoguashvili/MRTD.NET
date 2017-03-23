using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class DO87ProtectedCommandResponseCC : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IBinary _responseApduDo99;

        public DO87ProtectedCommandResponseCC(
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary responseApduDO99
            )
        {
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _responseApduDo99 = responseApduDO99;
        }
        public byte[] Bytes()
        {
            return new CC(
                    new K(
                        _incrementedSsc,
                        _responseApduDo99
                     ),
                    _kSmac
                ).Bytes();
        }
    }
}
