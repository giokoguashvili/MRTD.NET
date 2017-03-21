using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkSSC : IBinary
    {
        public byte[] Bytes()
        { 
            return new BinaryHex("887022120C06C226").Bytes();
        }
    }
}
