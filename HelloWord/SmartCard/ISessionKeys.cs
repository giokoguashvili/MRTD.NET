using HelloWord.Infrastructure;

namespace HelloWord.SmartCard
{
    public interface ISessionKeys
    {
        IBinary KSenc();
        IBinary KSmac();
        IBinary SSC();
    }
}