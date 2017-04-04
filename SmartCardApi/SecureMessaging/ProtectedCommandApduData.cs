using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging
{
    public class ProtectedCommandApduData : IBinary
    {
        private readonly IBinary _do87or97;
        private readonly IBinary _do8E;

        public ProtectedCommandApduData(
                IBinary do87or97,
                IBinary do8e
            )
        {
            _do87or97 = do87or97;
            _do8E = do8e;
        }

        public byte[] Bytes()
        {
            return new CombinedBinaries(
                _do87or97,
                _do8E
            ).Bytes();
        }
    }
}
