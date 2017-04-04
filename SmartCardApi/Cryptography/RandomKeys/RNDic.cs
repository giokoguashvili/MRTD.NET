using SmartCardApi.Commands;
using SmartCardApi.Infrastructure;
using SmartCardApi.ISO7816.ResponseAPDU.Body;
using SmartCardApi.SecureMessaging;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.Cryptography.RandomKeys
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
