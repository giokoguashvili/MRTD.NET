using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Org.BouncyCastle.Crypto.Paddings;
using SmartCardApi.Infrastructure;
using SmartCardApi.View;

namespace SmartCardApi.DataGroups.Content
{
    public class DG2Content
    {
        private readonly DataElements _dataElements;
        public DG2Content(IBinary dg2Data)
        {
            _dataElements = new DataElements(dg2Data);
        }

        public int BiometricInstacesNumber
        {
            get
            {
                return new IntHex(_dataElements.List()["02"])
                    .Value();
            }
        }

        public byte[] FaceImageData
        {
            get
            {
                var imageData = String.Empty;
                if (_dataElements.List().ContainsKey("5F2E")) imageData = _dataElements.List()["5F2E"];
                if (_dataElements.List().ContainsKey("7F2E")) imageData = _dataElements.List()["7F2E"];
                return new BinaryHex(
                            imageData
                       )
                       .Bytes()
                       .Skip(46) // Data Element may recur as defined by DE 01
                       .ToArray();
            }
        }
    }
}
