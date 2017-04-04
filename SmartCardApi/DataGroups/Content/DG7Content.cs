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
        [DllImport("kernel32.dll", EntryPoint = "GetConsoleWindow", SetLastError = true)]
        private static extern IntPtr GetConsoleHandle();

        private readonly IBerTLV _dg7DataBerTLV;
        public DG7Content(IBinary comData)
        {
            _dg7DataBerTLV = new BerTLV(comData);
        }

        public void SaveImage()
        {
            byte[] bitmap = new BinaryHex(_dg7DataBerTLV.Data[1].V).Bytes();
            //File.WriteAllBytes("output", bitmap);
            var handler = GetConsoleHandle();

            using (var graphics = Graphics.FromHwnd(handler))
            using (var image = Image.FromStream(new MemoryStream(bitmap)))
                graphics.DrawImage(image, 0, 0, 500, 500);
        }
    }
}
