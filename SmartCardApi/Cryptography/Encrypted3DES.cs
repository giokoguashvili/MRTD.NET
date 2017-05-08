using System.Security.Cryptography;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
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
            var textBytes = _text.Bytes();
            byte[] resultArray = _cTransform.TransformFinalBlock(textBytes, 0, textBytes.Length);
            return resultArray;
        }
    }
}
