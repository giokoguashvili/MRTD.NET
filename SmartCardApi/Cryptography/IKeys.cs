using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public interface IKeys
    {
        IBinary Key();
        IBinary Ka();
        IBinary Kb();
    }
}