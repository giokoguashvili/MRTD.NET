using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCSC;
using SmartCardApi.Commands;
using SmartCardApi.Cryptography.RandomKeys;
using SmartCardApi.Infrastructure;
using SmartCardApi.ISO7816.ResponseAPDU.Body;
using SmartCardApi.SecureMessaging;
using SmartCardApi.SmartCard;
using SmartCardApi.SmartCard.Reader;

namespace SmartCardApi.USB
{
    public class AuthenticatedReader
    {
        private readonly ISymbols _mrzInfo;

        public AuthenticatedReader(ISymbols mrzInfo)
        {
            _mrzInfo = mrzInfo;
        }

        public IReader Reader()
        {
            foreach (var connectedReader in new ConnectedReaders())
            {
                var wrappedReader = new WrappedReader(connectedReader);
                var _selectedMrtdApplication = new Cached(
                            new ExecutedCommandApdu(
                                new SelectMRTDApplicationCommandApdu(),
                                wrappedReader
                            )
                        );

                var kIfd = new Cached(new Kifd());
                var rndIc = new Cached(new RNDic(wrappedReader));
                var rndIfd = new Cached(new RNDifd());
                new ResponseApduData(
                    new Cached(
                        new ExecutedCommandApdu(
                            new ExternalAuthenticateCommandApdu(
                                new ExternalAuthenticateCommandData(
                                    _mrzInfo,
                                    rndIc,
                                    rndIfd,
                                    kIfd
                                )
                            ),
                            wrappedReader
                        )
                    )
                ).Bytes();
                return new SecuredReader(_mrzInfo, wrappedReader);
            }
            return null;
        } 
    }
}
