using System;
using System.Linq;

namespace HelloWord.Infrastructure
{
    public class Hex
    {
        private readonly IBinary _binary;

        public Hex(IBinary binary)
        { 
            this._binary = binary;
        }
        public override string ToString()
        {
            return this._binary
                .Bytes()
                .ToList()
                .Aggregate(
                    String.Empty,
                    (prev, next) => prev + next.ToString("X2")
                );
        }

        public int ToInt()
        {
            var strHex = new Hex(_binary).ToString();
            if (String.IsNullOrEmpty(strHex))
            {
                return 0;
            }
            return Int32.Parse(
                       strHex,
                       System.Globalization.NumberStyles.HexNumber
                   );
        } 
    }
}
