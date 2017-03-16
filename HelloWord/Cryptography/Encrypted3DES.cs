using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace HelloWord.Cryptography
{
    public class Crypted3DES : IBinary
    {
        private readonly IBinary _key;
        private readonly IBinary _text;
        private readonly ICryptoTransform _cTransform;
        public Crypted3DES(IBinary key, IBinary textForEncrypt, ICryptoTransform cTransform)
        {
            this._key = key;
            this._text = textForEncrypt;
            this._cTransform = cTransform;
        }
        public byte[] Bytes()
        {
            var textBytes = this._text.Bytes();
            byte[] resultArray = this._cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
            return resultArray;
        }
    }
}
