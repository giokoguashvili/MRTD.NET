using HelloWord.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SmartCard.DataElements
{
    public class DG1 : IBinary
    {
        public DG1(MiniLectorEVO miniLectorEvo)
        {

        }

        public byte[] Bytes()
        {
            throw new NotImplementedException();
        }
    }
}
