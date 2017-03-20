using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;

namespace HelloWord.Infrastructure
{
    public class CommandHeader : ICommandHeader
    {
        private readonly IBinary _rawCommandApdu;

        public CommandHeader(IBinary rawCommandAPDU)
        {
            _rawCommandApdu = rawCommandAPDU;
        }
        public IBinary CLA()
        {
            return new Binary(
                        _rawCommandApdu
                        .Bytes()
                        .Take(2)
                        .ToArray()
                    );
        }

        public IBinary INS()
        {
            return new Binary(
                        _rawCommandApdu
                        .Bytes()
                        .Skip(2)
                        .Take(2)
                        .ToArray()
                    );
        }

        public IBinary P1()
        {
            return new Binary(
                        _rawCommandApdu
                        .Bytes()
                        .Skip(4)
                        .Take(2)
                        .ToArray()
                    );
        }

        public IBinary P2()
        {
            return new Binary(
                        _rawCommandApdu
                        .Bytes()
                        .Skip(6)
                        .Take(2)
                        .ToArray()
                    );
        }

        public IBinary Header()
        {
            return new Binary(
                    _rawCommandApdu
                    .Bytes()
                    .Take(8)
                    .ToArray()
                );
        }

        public IBinary WithCLA(IBinary cla)
        {
            return new Binary(
                        cla
                        .Bytes()
                        .Concat(
                            _rawCommandApdu.Bytes().Skip(2).Take(6).ToArray()
                        ).ToArray()
                    );
        }
    }
}
