using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.ResponseDO.DO87;

namespace HelloWord.SecureMessaging.ResponseDO.ResponseDOFactory
{
    public class DO87ProtectedCommandResponseDOFactory : IProtectedCommandResponseDOFactory
    {
        public IBinary DO(IBinary commandResponse)
        {
            return new DO87ProtectedCommandResponseDO99(commandResponse);
        }

        public IBinary DO8E(IBinary commandResponse)
        {
            return new DO87ProtectedCommandResponseDO8E(commandResponse);
        }
    }
}
