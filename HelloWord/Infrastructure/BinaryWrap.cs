namespace HelloWord.Infrastructure
{
    public class Binary : IBinary
    {
        private readonly byte[] _bytes;

        public Binary() : this(new byte[0]) {}
        public Binary(byte[] bytes)
        {
            this._bytes = bytes;
        }
        public byte[] Bytes()
        {
            return this._bytes;
        }
    }
}
