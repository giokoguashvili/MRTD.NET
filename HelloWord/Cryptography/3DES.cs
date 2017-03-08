using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HelloWord.Cryptography
{
    public class TripleDES : IBinary
    {
        private readonly byte[] _keyBytes;
        private readonly byte[] _textBytes;

        public TripleDES(IBinary key, IBinary textForEncrypt) : this(key.AsBinary(), textForEncrypt.AsBinary()) { }
        public TripleDES(byte[] keyBytes, byte[] textBytes)
        {
            this._keyBytes = keyBytes;
            this._textBytes = textBytes;
        }
        public byte[] AsBinary()
        {
            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = this._keyBytes;
            tdes.Mode = CipherMode.CBC;
            tdes.IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            tdes.Padding = PaddingMode.None;
            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(this._textBytes, 0, this._textBytes.Length);
            tdes.Clear();
            return resultArray;
        }
    }
}
