using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Cryptography;
using HelloWord.Infrastructure;

namespace HelloWord.FileIds
{
    public class EF_COM : IBinary
    {
        private readonly string _fileId = "011E";
        public byte[] Bytes()
        {
            return new BinaryHex(_fileId).Bytes();
        }
    }
}
