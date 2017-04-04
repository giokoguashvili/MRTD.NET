using System;

namespace SmartCardApi.Infrastructure
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
