using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HelloWord.Cryptography
{
    public class MAC3 : IBinary
    {
        private readonly IBinary _eIfd;
        private readonly IBinary _kMac;
        public MAC3(IBinary eIfd, IBinary kMac)
        {
            this._eIfd = eIfd;
            this._kMac = kMac;
        }

        public byte[] Binary()
        {
            MACTripleDES mac = new MACTripleDES(this._kMac.Binary());
            mac.Initialize();
            mac.Padding = PaddingMode.None;
            mac.Key = this._kMac.Binary();
            
            var eIfd = this._eIfd.Binary();
            var mIfd = mac.TransformFinalBlock(eIfd, 0, eIfd.Length);
            return mIfd;
        }
    }
}
