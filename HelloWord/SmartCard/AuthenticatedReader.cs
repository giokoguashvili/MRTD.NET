using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelloWord.Commands;
using HelloWord.Cryptography;
using HelloWord.Cryptography.RandomKeys;
using HelloWord.Infrastructure;
using HelloWord.ISO7816.ResponseAPDU.Body;
using HelloWord.SecureMessaging;
using PCSC;

namespace HelloWord.SmartCard
{
    public class AuthenticatedReader : IAuthenticatedReader
    {
        private readonly IReader _reader;
        private readonly IBinary _selfIncrementSsc;
        private readonly IBinary _cachedKSenc;
        private readonly IBinary _cachedKSmac;
        private readonly IBinary _selectedMRTDApplication;

        public AuthenticatedReader(
                string mrzInfo,
                IReader reader
            )
        {
            _reader = reader;
            _selectedMRTDApplication = new Cached(
                                        new ExecutedCommandApdu(
                                            new SelectMRTDApplicationCommandApdu(),
                                            _reader
                                        )
                                    );

            var kIfd = new Cached(new Kifd());
            var rndIc = new Cached(new RNDic(_reader));
            var rndIfd = new Cached(new RNDifd());
            var externalAuthRespData = new ResponseApduData(
                                            new Cached(
                                                new ExecutedCommandApdu(
                                                    new ExternalAuthenticateCommandApdu(
                                                        new ExternalAuthenticateCommandData(
                                                            mrzInfo,
                                                            rndIc,
                                                            rndIfd,
                                                            kIfd
                                                        )
                                                    ),
                                                    _reader
                                                )
                                            )
                                        );

            var kSeedIc = new KseedIc(
                                kIfd,
                                new Kic(
                                    new R(
                                        externalAuthRespData,
                                        mrzInfo
                                    )
                                )
                            );

            _cachedKSenc = new Cached(new KSenc(kSeedIc));
            _cachedKSmac = new Cached(new KSmac(kSeedIc));
            _selfIncrementSsc = new SelfIncrementSSC(
                                    new Cached(
                                        new SSC(
                                            rndIc,
                                            rndIfd
                                        )
                                    )
                                );
        }
        public SCardError Transmit(IntPtr sendPci, byte[] sendBuffer, SCardPCI receivePci, ref byte[] receiveBuffer)
        {
            return _reader.Transmit(
                        sendPci,
                        sendBuffer,
                        receivePci,
                        ref receiveBuffer
                   );
        }

        public SCardProtocol ActiveProtocol()
        {
            _selectedMRTDApplication.Bytes();
            return _reader.ActiveProtocol();
        }


        public IBinary KSenc()
        {
            _selectedMRTDApplication.Bytes();
            return _cachedKSenc;
        }

        public IBinary KSmac()
        {
            _selectedMRTDApplication.Bytes();
            return _cachedKSmac;
        }

        public IBinary SelfIncrementedSSC()
        {
            return _selfIncrementSsc;
        }
    }
}
