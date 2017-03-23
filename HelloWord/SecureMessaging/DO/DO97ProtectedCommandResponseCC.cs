using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class DO97ProtectedCommandResponseCC : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IBinary _responseApduDo87;
        private readonly IBinary _responseApduDO87DO99;


        public DO97ProtectedCommandResponseCC(
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary responseApduDO87DO99
            )
        {
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _responseApduDO87DO99 = responseApduDO87DO99;
        }
        public byte[] Bytes()
        {
            return new CC(
                    new K(
                        _incrementedSsc,
                        _responseApduDO87DO99
                     ),
                    _kSmac
                ).Bytes();
        }
    }
}
