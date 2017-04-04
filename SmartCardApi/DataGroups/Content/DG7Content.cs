using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.DataGroups.Content
{
    public class DG7Content  
    {
 
        private readonly DataElements _dataElements;
        public DG7Content(IBinary dg7Data)
        {
            _dataElements = new DataElements(dg7Data);
        }

        public int NumberOfDisplaydImages
        {
            get
            {
                return new IntHex(
                         _dataElements
                                .List()["02"]
                    ).Value();
            }
        }
        public byte[] DisplayedSignatureImageData
        {
            get
            {
                return new BinaryHex(
                        _dataElements
                            .List()["5F43"]
                    ).Bytes();
            }
        }

        //public void SaveImage()
        //{
        //    byte[] bitmap = new BinaryHex(_dg7DataBerTLV.Data[1].V).Bytes();
        //    //File.WriteAllBytes("output", bitmap);
        //    var handler = GetConsoleHandle();

        //    using (var graphics = Graphics.FromHwnd(handler))
        //    using (var image = Image.FromStream(new MemoryStream(bitmap)))
        //        graphics.DrawImage(image, 0, 0, 500, 500);
        //}
    }
}
