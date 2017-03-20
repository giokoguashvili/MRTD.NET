using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using HelloWord.Infrastructure;
using PCSC.Iso7816;

namespace HelloWord.Cryptography
{
    /// <summary>
    /// 4.3.3.2 Authentication of Challenge and Response
    /// The cryptographic checksums MIFD and MIC SHALL be calculated using [ISO/IEC 9797-1] MAC algorithm 3 with blockcipher DES, 
    /// zero IV(8 bytes), and[ISO / IEC 9797 - 1] padding method 2. The MAC length MUST be 8 bytes.
    /// </summary>
    public class MAC3 : IBinary
    {
        private readonly IBinary _data;
        private readonly IBinary _key;
        public MAC3(IBinary data, IBinary key)
        {
            _data = data;
            _key = key;
        }

        //public byte[] Bytes()
        //{
        //    MACTripleDES mac = new MACTripleDES();
        //    mac.Initialize();
        //    mac.Padding = PaddingMode.Zeros;
        //    mac.Key = this._kMac.Bytes();

        //    var eIfd = this._eIfd.Bytes();
        //    var mIfd = mac.TransformFinalBlock(eIfd, 0, eIfd.Length);
        //    return mIfd;
        //}

        /// <summary>
        /// C# Implementation of Retail MAC Calculation (ISOIEC 9797-1 MAC algorithm 3)
        /// http://stackoverflow.com/questions/20312646/c-sharp-implementation-of-retail-mac-calculation-isoiec-9797-1-mac-algorithm-3
        /// </summary>
        /// <returns></returns>
        //public byte[] Bytes()
        //{
        //    var kMAC = this._kMac.Bytes();
        //    var eIfd = this._eIfd.Bytes();

        //    // Split the 16 byte MAC key into two keys
        //    byte[] key1 = new byte[8];
        //    Array.Copy(kMAC, 0, key1, 0, 8);
        //    byte[] key2 = new byte[8];
        //    Array.Copy(kMAC, 8, key2, 0, 8);


        //    // Padd the data with Padding Method 2 (Bit Padding)
        //    System.IO.MemoryStream out_Renamed = new System.IO.MemoryStream();
        //    out_Renamed.Write(eIfd, 0, eIfd.Length);
        //    out_Renamed.WriteByte((byte)(0x80));
        //    while (out_Renamed.Length % 8 != 0)
        //    {
        //        out_Renamed.WriteByte((byte)0x00);
        //    }
        //    byte[] eIfd_padded = out_Renamed.ToArray();


        //    // Split the blocks
        //    byte[] d1 = new byte[8];
        //    byte[] d2 = new byte[8];
        //    byte[] d3 = new byte[8];
        //    byte[] d4 = new byte[8];
        //    byte[] d5 = new byte[8];
        //    Array.Copy(eIfd_padded, 0, d1, 0, 8);
        //    Array.Copy(eIfd_padded, 8, d2, 0, 8);
        //    Array.Copy(eIfd_padded, 16, d3, 0, 8);
        //    Array.Copy(eIfd_padded, 24, d4, 0, 8);
        //    Array.Copy(eIfd_padded, 32, d5, 0, 8);

        //    DES des1 = DES.Create();
        //    des1.BlockSize = 64;
        //    des1.Key = key1;
        //    des1.Mode = CipherMode.CBC;
        //    des1.Padding = PaddingMode.None;
        //    des1.IV = new byte[8];

        //    DES des2 = DES.Create();
        //    des2.BlockSize = 64;
        //    des2.Key = key2;
        //    des2.Mode = CipherMode.CBC;
        //    des2.Padding = PaddingMode.None;
        //    des2.IV = new byte[8];

        //    // MAC Algorithm 3
        //    // Initial Transformation 1
        //    byte[] h1 = des1.CreateEncryptor().TransformFinalBlock(d1, 0, 8);
        //    // Iteration on the rest of blocks
        //    // XOR
        //    byte[] int2 = new byte[8];
        //    for (int i = 0; i < 8; i++)
        //        int2[i] = (byte)(h1[i] ^ d2[i]);
        //    // Encrypt
        //    byte[] h2 = des1.CreateEncryptor().TransformFinalBlock(int2, 0, 8);
        //    // XOR
        //    byte[] int3 = new byte[8];
        //    for (int i = 0; i < 8; i++)
        //        int3[i] = (byte)(h2[i] ^ d3[i]);
        //    // Encrypt
        //    byte[] h3 = des1.CreateEncryptor().TransformFinalBlock(int3, 0, 8);
        //    // XOR
        //    byte[] int4 = new byte[8];
        //    for (int i = 0; i < 8; i++)
        //        int4[i] = (byte)(h3[i] ^ d4[i]);
        //    // Encrypt
        //    byte[] h4 = des1.CreateEncryptor().TransformFinalBlock(int4, 0, 8);
        //    // XOR
        //    byte[] int5 = new byte[8];
        //    for (int i = 0; i < 8; i++)
        //        int5[i] = (byte)(h4[i] ^ d5[i]);
        //    // Encrypt
        //    byte[] h5 = des1.CreateEncryptor().TransformFinalBlock(int5, 0, 8);

        //    // Output Transformation 3
        //    byte[] h5decrypt = des2.CreateDecryptor().TransformFinalBlock(h5, 0, 8);
        //    byte[] mIfd = des1.CreateEncryptor().TransformFinalBlock(h5decrypt, 0, 8);

        //    return mIfd;
        //}

        // http://www.programcreek.com/java-api-examples/index.php?api=org.spongycastle.crypto.macs.ISO9797Alg3Mac
        public byte[] Bytes()
        {
            var cipher = new DesEngine();
            
            var mac = new ISO9797Alg3Mac(cipher, 64, new ISO7816d4Padding());
            KeyParameter keyP = new KeyParameter(_key.Bytes());
            mac.Init(keyP);
            mac.BlockUpdate(_data.Bytes(), 0, _data.Bytes().Length);
            byte[] _out = new byte[8];
            mac.DoFinal(_out, 0);
            return _out;
        }
    }
}
