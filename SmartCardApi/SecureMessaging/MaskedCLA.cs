using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging
{
    public class MaskedCLA : IBinary
    {
        private readonly byte _claMaks = 0x0C;
        private readonly IBinary _cla;

        public MaskedCLA(IBinary cla)
        {
            _cla = cla;
        }
        public byte[] Bytes()
        {
            return new byte[] {(byte) (_cla.Bytes().First() | _claMaks)};
        }
    }
}
