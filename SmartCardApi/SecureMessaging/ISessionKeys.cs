using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.SecureMessaging
{
    public interface ISessionKeys
    {
        IBinary KSenc();
        IBinary KSmac();
        IBinary SSC();
    }
}