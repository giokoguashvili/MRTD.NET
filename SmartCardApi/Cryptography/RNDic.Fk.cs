using SmartCardApi.Infrastructure;

namespace SmartCardApiTests.FakeObjects
{
    public class FkRNDic : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("4608F91988702212").Bytes();
        }
    }
}
