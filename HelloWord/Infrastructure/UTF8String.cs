using System.Text;

namespace HelloWord.Infrastructure
{
    public class UTF8String : IBinary
    {
        private readonly string _str;
        public UTF8String(string str)
        {
            _str = str;
        }

        public byte[] Bytes()
        {
            return Encoding.UTF8.GetBytes(_str);
        }
    }
}
