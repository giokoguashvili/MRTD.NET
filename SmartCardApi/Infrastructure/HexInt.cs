using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Infrastructure
{
    public class HexInt : IBinary
    {
        private readonly INumber _number;

        public HexInt(INumber number)
        {
            _number = number;
        }
        public HexInt(int number) 
            : this(new Number(number))
        {}

        public byte[] Bytes()
        {
            var hex = _number
                .Value()
                .ToString("X2");

            if (hex.Length % 2 != 0)
            {
                hex = "0" + hex;
            }
            return new BinaryHex(
                    hex
                ).Bytes();
        }
    }
}
