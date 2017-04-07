using SmartCardApi.Infrastructure;

namespace SmartCardApiTests.FakeObjects
{
    public class FkSSC : IBinary
    {
        public byte[] Bytes()
        { 
            return new BinaryHex("887022120C06C226").Bytes();
        }
    }
}
