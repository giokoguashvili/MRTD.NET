using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.ResponseDO.DO97;

namespace HelloWord.SecureMessaging.ResponseDO.ResponseDOFactory
{
    public class DO97ProtectedCommandResponseDOFactory : IProtectedCommandResponseDOFactory
    {
        public IBinary DO(IBinary commandResponse)
        {
            return new DO97ProtectedCommandResponseDO87DO99(commandResponse);
        }

        public IBinary DO8E(IBinary commandResponse)
        {
            return new DO97ProtectedCommandResponseDO8E(commandResponse);
        }
    }
}
