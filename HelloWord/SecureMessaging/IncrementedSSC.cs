using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.SecureMessaging
{
    public class IncrementedSSC : IBinary
    {
        private readonly IBinary _ssc;

        public IncrementedSSC(IBinary ssc)
        {
            _ssc = ssc;
        }
        public byte[] Bytes()
        {
            // icnrement last 4 byte by 0x01
            return
                _ssc
                    .Bytes()
                    .Take(4)
                    .Concat(
                        BitConverter
                            .GetBytes(
                                BitConverter.ToInt32(
                                        _ssc
                                        .Bytes()
                                        .Skip(4)
                                        .Reverse()
                                        .ToArray()
                                        , 0
                                    ) + 1
                            )
                            .Reverse()
                            .ToArray()
                    )
                    .ToArray();
                
        }
    }
}
