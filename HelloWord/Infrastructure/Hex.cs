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
            return Int32.Parse(
               new Hex(_binary).ToString(),
               System.Globalization.NumberStyles.HexNumber
           );
        } 
    }
}
