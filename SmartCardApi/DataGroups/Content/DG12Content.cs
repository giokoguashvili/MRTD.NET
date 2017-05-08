using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.DataGroups.Content
{
    public class DG12Content
    {
        private readonly DataElements _dataElements;
        public DG12Content(IBinary dg12Data)
        {
            _dataElements = new DataElements(dg12Data);
        }

        public string IssuingAuthority
        {
            get
            {
                return Encoding
                        .UTF8
                        .GetString(
                            new BinaryHex(_dataElements.List()["5F19"]).Bytes()
                        );
            }
        }

        public DateTime DateOfIssue
        {
            get
            {
                var data = Encoding
                        .UTF8
                        .GetString(
                            new BinaryHex(_dataElements.List()["5F26"]).Bytes()
                        );
                return new DateTime(
                            Int32.Parse(String.Concat(data.Take(4))),
                            Int32.Parse(String.Concat(data.Skip(4).Take(2))),
                            Int32.Parse(String.Concat(data.Skip(6).Take(2)))
                       );
            }
        }

        public string Endorsements
        {
            get
            {
                return Encoding
                        .UTF8
                        .GetString(
                            new BinaryHex(_dataElements.List()["5F1B"]).Bytes()
                        );
            }
        }
    }
}
