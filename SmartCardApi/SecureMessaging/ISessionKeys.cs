using SmartCardApi.Infrastructure;

namespace SmartCardApi.SecureMessaging
{
    public interface ISessionKeys
    {
        IBinary KSenc();
        IBinary KSmac();
        IBinary SSC();
    }
}