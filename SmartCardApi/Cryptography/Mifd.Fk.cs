using SmartCardApi.Infrastructure;

namespace SmartCardApiTests.FakeObjects
{
    public class FkMifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("5F1448EEA8AD90A7").Bytes();
        }
    }
}
