using System.Linq;
using System.Text;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.DataGroups.Content
{
    public class DG1Content 
    {
        private readonly DataElements _dataElements;
        public DG1Content(IBinary dg1Data)
        {
            _dataElements = new DataElements(dg1Data);
        }

        public string MRZ
        {
            get
            {
                return Encoding.ASCII.GetString(
                    new BinaryHex(_dataElements.List()["5F1F"]).Bytes()
                );
            }
        }
    }
}
