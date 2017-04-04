using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.DataGroups.Content
{
    public class DG2Content
    {
        private readonly IBerTLV _dg2DataBerTLV;
        public DG2Content(IBinary comData)
        {
            _dg2DataBerTLV = new BerTLV(comData);
        }

        public void SaveImage()
        {
            byte[] bitmap = new BinaryHex(_dg2DataBerTLV.Data[0].Data[1].Data[1].V).Bytes().Skip(46).ToArray();
            File.WriteAllBytes("dg2.jpeg", bitmap);
            //using (Image image = Image.FromStream(new MemoryStream(bitmap)))
            //{
            //    image.Save("output2.jpg", ImageFormat.Jpeg);  // Or Png
            //}
        }
    }
}
