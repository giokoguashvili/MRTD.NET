using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.CC
{
    public class CC : IBinary
    {
        private readonly IBinary _incrementedSsc;
        private readonly IBinary _kSmac;
        private readonly IBinary _m;

        public CC(
                IBinary incrementedSsc,
                IBinary kSmac,
                IBinary m
            )
        {
            _incrementedSsc = incrementedSsc;
            _kSmac = kSmac;
            _m = m;
        }
        public byte[] Bytes()
        {
            return new MAC3(
                    new N(
                        _incrementedSsc,
                        _m
                    ),
                    _kSmac
                ).Bytes(); 
        }
    }
}
