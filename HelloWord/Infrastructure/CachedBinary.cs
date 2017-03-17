namespace HelloWord.Infrastructure
{
    public class CachedBinary : IBinary
    {
        private readonly IBinary _src;
        private byte[] _cachedBytes = new byte[0];
        public CachedBinary(IBinary src)
        {
            this._src = src;
        }

        public byte[] Bytes()
        {
            if (this._cachedBytes.Length == 0)
            {
                this._cachedBytes = this._src.Bytes();
            }
            return this._cachedBytes;
        }
    }
}
