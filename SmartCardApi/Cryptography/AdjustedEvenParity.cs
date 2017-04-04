namespace SmartCardApi.Cryptography
{
    public class AdjustedEvenParity : IParity
    {
        private readonly byte _b;

        public AdjustedEvenParity(byte b)
        {
            _b = b;
        }

        public IParity Adjusted()
        {
            return this;
        }

        public byte Result()
        {
            return (byte)((_b >> 1) << 1);
        }
    }
}