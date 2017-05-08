using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public interface ICryptographer
    {
        IBinary Decrypted();
        IBinary Encrypted();
    }
}