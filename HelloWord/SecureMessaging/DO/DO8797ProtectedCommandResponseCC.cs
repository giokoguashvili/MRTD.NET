using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class DO8797ProtectedCommandResponseCC : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IBinary _do87OrDo99ProtectedCommandResponse;

        public DO8797ProtectedCommandResponseCC(
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary do87OrDo99ProtectedCommandResponse
            )
        {
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _do87OrDo99ProtectedCommandResponse = do87OrDo99ProtectedCommandResponse;
        }
        public byte[] Bytes()
        {
            return new CC(
                    new K(
                        _incrementedSsc,
                        _do87OrDo99ProtectedCommandResponse
                     ),
                    _kSmac
                ).Bytes();
        }
    }
}
