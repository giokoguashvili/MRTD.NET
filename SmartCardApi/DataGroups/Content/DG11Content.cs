using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.DataGroups.Content
{
    public class DG11Content
    {
        private readonly DataElements _dataElements;
        public DG11Content(IBinary dg1Data)
        {
            _dataElements = new DataElements(dg1Data);
        }

        public string FullNameOfDocumentHolder
        {
            get
            {
                return Encoding
                            .UTF8
                            .GetString(
                                new BinaryHex(_dataElements.List()["5F0E"]).Bytes()
                            );
            }
        }

        public string PersonalNumber
        {
            get
            {
                return Encoding
                            .UTF8
                            .GetString(
                                new BinaryHex(_dataElements.List()["5F10"]).Bytes()
                            );
            }
        }

        public string PlaceOfBirth
        {
            get
            {
                return Encoding
                            .UTF8
                            .GetString(
                                 new BinaryHex(_dataElements.List()["5F11"]).Bytes()
                            );
            }
        }
    }
}
