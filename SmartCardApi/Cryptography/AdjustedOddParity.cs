namespace SmartCardApi.Cryptography
{
    public class AdjustedOddParity : IParity
    {
        private readonly byte _b;
        public AdjustedOddParity(byte b)
        {
            _b = b;
        }

        public IParity Adjusted()
        {
            return this;
        }

        public byte Result()
        {
            return (byte)(_b | 1);
        }
    }
}