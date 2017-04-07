using SmartCardApi.Infrastructure;

namespace SmartCardApiTests.FakeObjects
{
    public class FkRNDifd : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("781723860C06C226").Bytes();
        }
    }
}
