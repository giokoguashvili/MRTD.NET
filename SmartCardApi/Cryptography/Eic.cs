using System.Linq;
using SmartCardApi.Infrastructure;
using SmartCardApi.Infrastructure.Interfaces;

namespace SmartCardApi.Cryptography
{
    public class Eic : IBinary
    {
        private readonly IBinary _externalAuthenticateResponseData;

        public Eic(IBinary externalAuthenticateResponseData)
        {
            _externalAuthenticateResponseData = externalAuthenticateResponseData;
        }
        public byte[] Bytes()
        {
            return _externalAuthenticateResponseData
                .Bytes()
                .Take(32)
                .ToArray();
        }
    }
}
