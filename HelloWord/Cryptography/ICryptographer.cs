namespace HelloWord.Cryptography
{
    public interface ICryptographer
    {
        IBinary Decrypted();
        IBinary Encrypted();
    }
}