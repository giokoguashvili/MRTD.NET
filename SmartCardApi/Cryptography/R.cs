using SmartCardApi.Infrastructure;
using SmartCardApi.MRZ;
using SmartCardApi.SecureMessaging.Decryption;
using SmartCardApi.SmartCard;

namespace SmartCardApi.Cryptography
{
    public class R : IBinary
    {
        private readonly IBinary _externalAuthRespData;
        private readonly ISymbols _mrzInformation;

        public R(
                IBinary externalAuthRespData,
                ISymbols mrzInformation
            )
        {
            _externalAuthRespData = externalAuthRespData;
            _mrzInformation = mrzInformation;
        }
        public byte[] Bytes()
        {
            return new DecryptedExternalAuthenticateResponseData(
                    _externalAuthRespData,
                    _mrzInformation
                ).Bytes();
        }
    }
}
