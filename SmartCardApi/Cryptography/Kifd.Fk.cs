using SmartCardApi.Infrastructure;

namespace SmartCardApiTests.FakeObjects
{
    public class FkKifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("0B795240CB7049B01C19B33E32804F0B").Bytes();
        }
    }
}
