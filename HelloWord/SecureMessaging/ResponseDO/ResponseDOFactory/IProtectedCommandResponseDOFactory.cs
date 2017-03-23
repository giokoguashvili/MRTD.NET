using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.ResponseDO.ResponseDOFactory
{
    public interface IProtectedCommandResponseDOFactory
    {
        IBinary DO(IBinary commandResponse);
        IBinary DO8E(IBinary commandResponse);
    }
}
