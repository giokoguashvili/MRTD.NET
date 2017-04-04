using System.Linq;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public class WithoutPad : IBinary
    {
        private readonly IBinary _data;

        public WithoutPad(IBinary data)
        {
            _data = data;
        }
        public byte[] Bytes()
        {
            return _data
                .Bytes()
                .Reverse()
                .SkipWhile(b => b == 0x00)
                .Skip(1)
                .Reverse()
                .ToArray();
        }
    }
}
