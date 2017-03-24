using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging.DO
{
    public class ParsedDO87 : IBinary
    {
        private readonly IBinary _protectedResponseApdu;

        public ParsedDO87(IBinary protectedResponseApdu)
        {
            _protectedResponseApdu = protectedResponseApdu;
        }
        public byte[] Bytes()
        {
            //new Hex(_protectedResponseApdu)
            //        .ToString()
            //        .Split(new[] { "87" }, StringSplitOptions.None)
            //        .Where();
            //return 
            throw new NotFiniteNumberException();
        }
    }
}
