using HelloWord.Infrastructure;
using HelloWord.SecureMessaging.DO;

namespace HelloWord.SecureMessaging.ResponseDO
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
