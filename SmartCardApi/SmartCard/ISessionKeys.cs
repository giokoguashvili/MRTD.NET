using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard
{
    public interface ISessionKeys
    {
        IBinary KSenc();
        IBinary KSmac();
        IBinary SSC();
    }
}