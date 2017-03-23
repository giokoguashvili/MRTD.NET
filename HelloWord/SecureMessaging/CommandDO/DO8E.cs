using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.CommandDO
{
    public class DO8E : IBinary
    {
        private readonly IBinary _cc;
        private byte[] _do8e = new byte[] { 0x8E, 0x08 };

        public DO8E(IBinary cc)
        {
            _cc = cc;
        }
        public byte[] Bytes()
        {
            return new ConcatenatedBinaries(
                        new Binary(_do8e),
                        _cc
                    ).Bytes();
        }
    }
}
