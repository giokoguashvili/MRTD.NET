using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.MRZ;

namespace SmartCardApi.DataGroups.Content
{
    public class DG1Content 
    {
        private readonly DataElements _dataElements;
        public DG1Content(IBinary dg1Data)
        {
            _dataElements = new DataElements(dg1Data);
        }

        public ParsedMRZ MRZ
        {
            get
            {

                return new ParsedMRZ(_dataElements.List()["5F1F"]);
            }
        }
    }
}
