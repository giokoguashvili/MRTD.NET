using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.ISO7816.ResponseAPDU.Trailer
{
    public class SW1 : IBinary
    {
        private readonly IBinary _responseApduTrailer;

        public SW1(IBinary responseApduTrailer)
        {
            _responseApduTrailer = responseApduTrailer;
        }
        public byte[] Bytes()
        {
            return _responseApduTrailer
                .Bytes()
                .Take(1)
                .ToArray();
        }
    }
}
