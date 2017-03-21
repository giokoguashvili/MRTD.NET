using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Infrastructure;

namespace UnitTests.FakeObjects
{
    public class FkKSmac : IBinary
    {
        public byte[] Bytes()
        {
            return new BinaryHex("F1CB1F1FB5ADF208806B89DC579DC1F8").Bytes();
        }
    }
}
