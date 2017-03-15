using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;

namespace HelloWord.Cryptography
{
    /// <summary>
    /// ICAO Doc 9303
    /// Part 11: Security Mechanisms for MRTDs / Page: 17
    /// http://www.icao.int/publications/pages/publication.aspx?docnum=9303
    ///
    /// 3DES[FIPS 46 - 3] SHALL be used in Retail-mode according to[ISO / IEC 9797 - 1] MAC algorithm 3 / padding method 2
    /// with block cipher DES and IV = 0.
    /// </summary>
    public class TripleDES : IBinary
    {
        private readonly IBinary _key;
        private readonly IBinary _text;

        public TripleDES(IBinary key, IBinary textForEncrypt)
        {
            this._key = key;
            this._text = textForEncrypt;
        }

        public byte[] Binary()
        {
            using (
                var tdes = new TripleDESCryptoServiceProvider()
                {
                    Key = this._key.Binary(),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.None,
                    IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
                }
            )
            {
                ICryptoTransform cTransform = tdes.CreateEncryptor();
                var textBytes = this._text.Binary();
                byte[] resultArray = cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                tdes.Clear();
                return resultArray;
            }
        }
    }
}
