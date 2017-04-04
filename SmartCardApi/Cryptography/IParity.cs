namespace SmartCardApi.Cryptography
{
    public interface IParity
    {
        IParity Adjusted();
        byte Result();
    }
}