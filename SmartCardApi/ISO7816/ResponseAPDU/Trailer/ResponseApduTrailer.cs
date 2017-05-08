using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.ISO7816.ResponseAPDU.Trailer
{
    public class ResponseApduTrailer : IBinary
    {
        private readonly IBinary _executedCommandApdu;
        private readonly int _responseApduTrailerLength = 2; // len(SW1) + len(SW2) = 2 bytes

        public ResponseApduTrailer(IBinary executedCommandApdu)
        {
            _executedCommandApdu = executedCommandApdu;
        }
        public byte[] Bytes()
        {
            return _executedCommandApdu
                  .Bytes()
                  .Reverse()
                  .Take(_responseApduTrailerLength)
                  .Reverse()
                  .ToArray();
        }
    }
}
