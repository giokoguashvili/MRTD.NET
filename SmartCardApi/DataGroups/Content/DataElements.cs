using System.Collections.Generic;
using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.View;

namespace SmartCardApi.DataGroups.Content
{
    public class DataElements
    {
        private readonly BerTLVTree _dgDataTLV;
        private Dictionary<string, string> _dataElements;
        public DataElements(IBinary dgData)
        {
                _dgDataTLV = new BerTLVTree(new BerTLV(dgData));
        }

        private Dictionary<string, string> DataElementsList
        {
            get
            {
                if (_dataElements == null)
                {
                    _dataElements = _dgDataTLV
                                        .DFS()
                                        .ToDictionary(tlv => tlv.T, tlv => tlv.V);
                }
                return _dataElements;
            }
        }
        public Dictionary<string, string> List()
        {
            return DataElementsList;
        }
    }
}
