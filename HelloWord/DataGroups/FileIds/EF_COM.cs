using HelloWord.Infrastructure;

namespace HelloWord.DataGroups.FileIds
{
    public class EF_COM : IBinary
    {
        private readonly string _fileId = "011E";
        public byte[] Bytes()
        {
            return new BinaryHex(_fileId).Bytes();
        }
    }
}
