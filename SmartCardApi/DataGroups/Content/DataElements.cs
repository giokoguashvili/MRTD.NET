using System;
using System.Collections.Generic;
using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;
using SmartCardApi.View;

namespace SmartCardApi.DataGroups.Content
{
    public class DataElements
    {
        private readonly Lazy<Dictionary<string, string>> _dataElementsLazy;
        public DataElements(IBinary dgData)
        {
            var dgDataTlv = new BerTLVTree(new BerTLV(dgData));
            _dataElementsLazy = new Lazy<Dictionary<string, string>>(
                    () => dgDataTlv
                                .DFS()
                                .ToDictionary(tlv => tlv.T, tlv => tlv.V)
                );
        }

        public Dictionary<string, string> List()
        {
            return _dataElementsLazy.Value;
        }
    }
}
