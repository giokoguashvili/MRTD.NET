using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class COMFileStructureLength : IBinary
    {
        private readonly byte _firstFourByte = 4;
        public COMFileStructureLength()
        {
                
        }
        public byte[] Bytes()
        {
            throw new NotImplementedException();
            //return new ReadBinaryCommand(_firstFourByte);
        }
    }
}
