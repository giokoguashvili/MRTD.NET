using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.ISO7816.ResponseAPDU.Trailer
{
    public class SW2 : IBinary
    {
        private readonly IBinary _responseApduTrailer;

        public SW2(IBinary responseApduTrailer)
        {
            _responseApduTrailer = responseApduTrailer;
        }
        public byte[] Bytes()
        {
            return _responseApduTrailer
                .Bytes()
                .Skip(1)
                .Take(1)
                .ToArray();
        }
    }
}
