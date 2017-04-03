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
using HelloWord.SmartCard.Reader;

namespace HelloWord.SmartCard
{
    public class SessionKeys : ISessionKeys
    {
        private readonly IBinary _ssc;
        private readonly IBinary _cachedKSenc;
        private readonly IBinary _cachedKSmac;
        private readonly IBinary _selectedMrtdApplication;

        public SessionKeys(
                string mrzInfo,
                IReader reader
            )
        {
            _selectedMrtdApplication = new Cached(
                                        new ExecutedCommandApdu(
                                            new SelectMRTDApplicationCommandApdu(),
                                            reader
                                        )
                                    );

            var kIfd = new Cached(new Kifd());
            var rndIc = new Cached(new RNDic(reader));
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
                                                    reader
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
            _ssc = new Cached(
                        new SSC(
                            rndIc,
                            rndIfd
                        )
                    );
        }

        public IBinary KSenc()
        {
            _selectedMrtdApplication.Bytes();
            return _cachedKSenc;
        }

        public IBinary KSmac()
        {
            _selectedMrtdApplication.Bytes();
            return _cachedKSmac;
        }

        public IBinary SSC()
        {
            _selectedMrtdApplication.Bytes();
            return _ssc;
        }
    }
}
