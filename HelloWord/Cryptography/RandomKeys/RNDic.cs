using HelloWord.CommandAPDU;
using PCSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Infrastructure;

namespace HelloWord.Cryptography.RandomKeys
{
    public class RNDic : IBinary
    {
        private ICommandAPDU _executedGetChallengeCommand;
        private readonly ISCardReader _reader;
        private RNDic(ICommandAPDU executedGetChallengeCommand)
        {
            this._executedGetChallengeCommand = executedGetChallengeCommand;
        }

        public RNDic(ISCardReader reader)
            : this(
                        new ExecutedCommandAPDU(
                            new GetChallengeCommand(),
                            reader
                        )
                  )
        { }

        public byte[] Bytes()
        {
            return new ResponseAPDU(this._executedGetChallengeCommand)
                .Body()
                .Bytes();
        }
    }
}
