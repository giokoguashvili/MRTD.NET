using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public interface IKeys
    {
        IBinary Key();
        IBinary Ka();
        IBinary Kb();
    }
}