using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HelloWord.Infrastructure;
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
    public class TripleDES : ICryptographer
    {
        private readonly IBinary _key;
        private readonly IBinary _text;
        private readonly TripleDESCryptoServiceProvider _cryptoService;

        public TripleDES(IBinary key, IBinary textForEncrypt)
        {
            this._key = key;
            this._text = textForEncrypt;
            this._cryptoService = new TripleDESCryptoServiceProvider()
            {
                Key = this._key.Bytes(),
                Mode = CipherMode.CBC,
                Padding = PaddingMode.None,
                IV = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 },
            };
        }

        public IBinary Decrypted()
        {
            return new Crypted3DES(
                    this._key,
                    this._text,
                    _cryptoService.CreateDecryptor()
                );
        }

        public IBinary Encrypted()
        {
            return new Crypted3DES(
                    this._key,
                    this._text,
                    _cryptoService.CreateEncryptor()
                );
        }
    }
}
