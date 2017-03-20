using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;

namespace HelloWord.Infrastructure
{
    public class CommandHeader : ICommandAPDUHeader
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
                        .Take(1)
                        .ToArray()
                    );
        }

        public IBinary INS()
        {
            return new Binary(
                        _rawCommandApdu
                        .Bytes()
                        .Skip(1)
                        .Take(1)
                        .ToArray()
                    );
        }

        public IBinary P1()
        {
            return new Binary(
                        _rawCommandApdu
                        .Bytes()
                        .Skip(2)
                        .Take(1)
                        .ToArray()
                    );
        }

        public IBinary P2()
        {
            return new Binary(
                        _rawCommandApdu
                        .Bytes()
                        .Skip(3)
                        .Take(1)
                        .ToArray()
                    );
        }

        public IBinary Header()
        {
            return new Binary(
                    _rawCommandApdu
                    .Bytes()
                    .Take(4)
                    .ToArray()
                );
        }

        public IBinary WithCLA(IBinary cla)
        {
            return new Binary(
                        cla
                        .Bytes()
                        .Concat(
                            _rawCommandApdu.Bytes().Skip(1).Take(3).ToArray()
                        ).ToArray()
                    );
        }

        //public IBinary Lc()
        //{
        //    return new Binary(
        //                _rawCommandApdu
        //                .Bytes()
        //                .Skip(4)
        //                .Take(1)
        //                .ToArray()
        //            );
        //}

        //public IBinary Data()
        //{
        //    return new Binary(
        //                _rawCommandApdu
        //                .Bytes()
        //                .Skip(5)
        //                .Take(BitConverter.ToInt32(Lc().Bytes(), 0))
        //                .ToArray()
        //            );
        //}
    }
}
