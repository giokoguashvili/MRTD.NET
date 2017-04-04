using SmartCardApi.Infrastructure;

namespace SmartCardApi.Cryptography
{
    public interface ICryptographer
    {
        IBinary Decrypted();
        IBinary Encrypted();
    }
}