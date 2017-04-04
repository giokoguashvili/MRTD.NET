using SmartCardApi.Cryptography;
using SmartCardApi.Infrastructure;

namespace SmartCardApi.SmartCard
{
    public class DecryptedExternalAuthenticateResponseData : IBinary
    {
        private readonly IBinary _externalAuthRespData;
        private readonly string _mrzInformation;

        public DecryptedExternalAuthenticateResponseData(
                IBinary externalAuthRespData,
                string mrzInformation
            )
        {
            _externalAuthRespData = externalAuthRespData;
            _mrzInformation = mrzInformation;
        }
        public byte[] Bytes()
        {
            return new TripleDES(
                    new Kenc(_mrzInformation),
                    new Eic(_externalAuthRespData)
                )
                .Decrypted()
                .Bytes();
        }
    }
}
