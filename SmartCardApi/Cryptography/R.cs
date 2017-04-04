using SmartCardApi.Infrastructure;
using SmartCardApi.SmartCard;

namespace SmartCardApi.Cryptography
{
    public class R : IBinary
    {
        private readonly IBinary _externalAuthRespData;
        private readonly string _mrzInformation;

        public R(
                IBinary externalAuthRespData,
                string mrzInformation
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
