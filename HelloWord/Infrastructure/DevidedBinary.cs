using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.Infrastructure
{
    public class DevidedBinary : IBinary
    {
        private readonly IBinary _binary;
        public DevidedBinary(IBinary binary)
        {
            _binary = binary;
        }

        public byte[] Bytes()
        {
            throw new NotImplementedException();
        }
    }
}
