using PCSC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HelloWord.Commands;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.SecureMessaging;
using HelloWord.SmartCard;
using HelloWord.SmartCard.Reader;

namespace HelloWord.Cryptography.RandomKeys
{
    public class RNDic : IBinary
    {
        private IBinary _executedGetChallengeCommand;
        private readonly IReader _reader;
        private RNDic(IBinary executedGetChallengeCommand)
        {
            _executedGetChallengeCommand = executedGetChallengeCommand;
        }

        public RNDic(IReader reader)
            : this(
                        new Cached(
                            new ExecutedCommandApdu(
                                new GetChallengeCommandApdu(),
                                reader
                            )
                        )
                  )
        { }

        public byte[] Bytes()
        {
            return new ResponseApduData(_executedGetChallengeCommand)
                    .Bytes();
        }
    }
}
