using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography
{
    public class Crypted3DES : IBinary
    {
        private readonly IBinary _text;
        private readonly ICryptoTransform _cTransform;
        public Crypted3DES(
                IBinary textForEncrypt, 
                ICryptoTransform cTransform
            )
        {
            _text = textForEncrypt;
            _cTransform = cTransform;
        }
        public byte[] Bytes()
        {
            var textBytes = this._text.Bytes();
            byte[] resultArray = this._cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
            return resultArray;
        }
    }
}
